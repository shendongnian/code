    [TestClass]
    public class SampleTests
    {
        [TestMethod]
        public void Test()
        {
            for (var i = 0; i < 10; ++i)
                XamlTestManager.ConductTest(i); 
        }
    }
