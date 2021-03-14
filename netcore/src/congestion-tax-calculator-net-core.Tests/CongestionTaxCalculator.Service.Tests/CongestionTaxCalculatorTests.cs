
namespace CongestionTaxCalculator.Service.Tests
{
    using Moq;
    using NUnit.Framework;
    using System;

    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void GetTax_WhenNonTollFreeDatesAndNonTollFreeVehicle_CorrectTaxValue()
        {
            // Arrange
            var expectedTax = 16;
            DateTime[] stationPasses = { new DateTime(2013, 5, 10, 6, 23, 30), new DateTime(2013, 5, 10, 8, 43, 00) };
            var nonTollFreeVehicleMock = new Mock<Vehicle>();
            nonTollFreeVehicleMock.Setup(mock => mock.GetVehicleType()).Returns("Car");

            // Act
            var congestionTaxCalculator = new CongestionTaxCalculator();
            var calculatedTax = congestionTaxCalculator.GetTax(nonTollFreeVehicleMock.Object, stationPasses);

            // Assert
            Assert.AreEqual(calculatedTax, expectedTax);
        }
    }
}