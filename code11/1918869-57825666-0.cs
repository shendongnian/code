    [TestFixture]
    public class ThermostatTests
    {
        private ThermostatController thermostat;
        [SetUp]
        public void Init()
        {
           thermostat = new ThermostatController();
        }
        [Test]
        public void ReturnsCurrentTemperature()
        {
            thermostat.Reset();
            int actual = thermostat.GetTemp();
            int expected = 20;
            Assert.AreEqual(expected, actual);
        }
    }
