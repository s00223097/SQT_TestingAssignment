using Moq;
using NUnit.Framework;
using NUnit_TestingAssignment;
namespace NUnit.assignment
{
    [TestFixture]
    public class InsuranceServiceTests
    {
        private Mock<IDiscountService> mockDiscountService;

        [SetUp]
        public void Setup()
        {
            mockDiscountService = new Mock<IDiscountService>();
        }

        [Test]
        public void CalcPremium_WhenAgeBelow18AndLocationRural_ReturnsZero()
        {
            // Arrange
            var insuranceService = new InsuranceService(mockDiscountService.Object);

            // Act
            var result = insuranceService.CalcPremium(17, "rural");

            // Assert
            Assert.That(result, Is.EqualTo(0.0));
        }

        [Test]
        public void CalcPremium_WhenAgeBetween18And30AndLocationRural_ReturnsPremiumOfFive()
        {
            // Arrange
            var insuranceService = new InsuranceService(mockDiscountService.Object);

            // Act
            var result = insuranceService.CalcPremium(18, "rural");

            // Assert
            Assert.That(result, Is.EqualTo(5.0));
        }

        [Test]
        public void CalcPremium_WhenAgeBetween31And49AndLocationRural_ReturnsPremiumOfTwoPointFive()
        {
            // Arrange
            var insuranceService = new InsuranceService(mockDiscountService.Object);

            // Act
            var premium = insuranceService.CalcPremium(31, "rural");

            // Assert
            Assert.That(premium, Is.EqualTo(2.5));
        }

        [Test] 
        public void CalcPremium_WhenAge50OrAboveAndLocationRural_ReturnsDiscountedPremium()
        {
            // Arrange
            mockDiscountService.Setup(x => x.GetDiscount()).Returns(0.9);
            var insuranceService = new InsuranceService(mockDiscountService.Object);

            // Act
            var premium = insuranceService.CalcPremium(50, "rural");

            // Assert
            Assert.That(premium, Is.EqualTo(2.25));
        }

        [Test]
        public void CalcPremium_WhenLocationUrbanAndAgeBelow18_ReturnsZero()
        {
            // Arrange
            var insuranceService = new InsuranceService(mockDiscountService.Object);

            // Act
            var result = insuranceService.CalcPremium(17, "urban");

            // Assert
            Assert.That(result, Is.EqualTo(0.0));
        }

        [Test]
        public void CalcPremium_WhenAgeBetween18And35AndLocationUrban_ReturnsPremiumOfSix()
        {
            // Arrange
            var insuranceService = new InsuranceService(mockDiscountService.Object);

            // Act
            var result = insuranceService.CalcPremium(20, "urban");

            // Assert
            Assert.That(result, Is.EqualTo(6.0));
        }

        [Test]
        public void CalcPremium_WhenAgeAbove35AndLocationUrban_ReturnsPremiumOfFive()
        {
            // Arrange
            var insuranceService = new InsuranceService(mockDiscountService.Object);

            // Act
            var result = insuranceService.CalcPremium(36, "urban");

            // Assert
            Assert.That(result, Is.EqualTo(5.0));
        }

        [Test]
        public void CalcPremium_WhenAge50OrAboveAndLocationUrban_ReturnsDiscountedPremium()
        {
            // Arrange
            mockDiscountService.Setup(x => x.GetDiscount()).Returns(0.9);
            var insuranceService = new InsuranceService(mockDiscountService.Object);

            // Act
            var result = insuranceService.CalcPremium(50, "urban");

            // Assert
            Assert.That(result, Is.EqualTo(4.5));
        }

        [Test]
        public void CalcPremium_WhenLocationIsInvalid_ReturnsZero()
        {
            // Arrange
            var insuranceService = new InsuranceService(mockDiscountService.Object);

            // Act
            var result = insuranceService.CalcPremium(25, "invalid");

            // Assert
            Assert.That(result, Is.EqualTo(0.0));
        }

        [Test]
        public void CalcPremium_WhenAgeIsZeroAndLocationIsRural_ReturnsZero()
        {
            // Arrange
            var insuranceService = new InsuranceService(mockDiscountService.Object);

            // Act
            var result = insuranceService.CalcPremium(0, "rural");

            // Assert
            Assert.That(result, Is.EqualTo(0.0));
        }

        [Test]
        public void CalcPremium_WhenAgeIs100AndLocationIsUrban_ReturnsPremiumOfFive()
        {
            // Arrange
            var mockDiscountService = new Mock<IDiscountService>();
            mockDiscountService.Setup(d => d.GetDiscount()).Returns(1.0); // Set up the mock object to return a discount of 1.0

            var insuranceService = new InsuranceService(mockDiscountService.Object);

            // Act
            var result = insuranceService.CalcPremium(100, "urban");

            // Assert
            Assert.That(result, Is.EqualTo(5.0));
        }

    }
}
