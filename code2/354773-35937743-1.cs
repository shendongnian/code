    [TestClass]
    public class MyUnitTest
    {
        [TestCleanup]
        public void CleanupTest()
        {
            //
            // Clear any app settings that were applied for the current test runner thread.
            //
            AppSettings.Instance = null;
        }
        [TestMethod]
        public void MyUnitMethod()
        {
            AppSettings.Instance = new AppSettings(setting1: "New settings value for current thread");
            // Your test code goes here
        }
    }
