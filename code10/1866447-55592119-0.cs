    public class UnitTest
    {
        private readonly string _configValue = ConfigurationManager.AppSettings["test"];
        [Test]
        public void Test()
        {
            Assert.AreEqual("testValue", _configValue);
        }
    }
