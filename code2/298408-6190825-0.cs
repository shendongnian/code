    [TestClass]
    public class AssemblyTestHarness
    {
        [AssemblyInitialize]
        public static void InitializeAssembly(TestContext context)
        {
            // start process here
        }
        [AssemblyCleanup]
        public static void CleanupAssembly(TestContext context)
        {
            // clean-up process here
        }
    }
