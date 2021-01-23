    [TestClass]
    public class MyTestFixture
    {
        [ClassInitialize]
        public static void InitializeFixture(TestContext context)
        {
            // start process here
        }
        [ClassCleanup]
        public static void CleanupFixture(TestContext context)
        {
            // clean-up process here
        }
    }
