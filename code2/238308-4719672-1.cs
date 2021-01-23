    [TestClass]
    public class Tests : MsTestExtensionsTestFixture
    {
        [TestMethod, ExpectedExceptionMessage(typeof(System.FormatException), "blah")]
        public void Validate()
        {
            int.Parse("dfd");
        }
    }
