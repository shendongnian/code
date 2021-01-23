    [TestClass]
    public class TestBase
    {
        public TestBase()
        {
            // Initialization Code
        }
    }
    
    [TestClass]
    public class TestMapping : TestBase
    {
        [TestMethod]
        public void Test1()
        {
            // At this point the base constructor should have been called
        }
    }
