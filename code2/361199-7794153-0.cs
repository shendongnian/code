    [TestFixture]
    public class ScreenshotTest
    {
        private IE ie;
        [SetUp]
        public void DoTestSetup()
        {
            ie = new IE();
        }
        [TearDown]
        public void DoTestTeardown()
        {
            if (ie != null)
            {
                if (TestContext.CurrentContext.Outcome == TestOutcome.Failed)
                    ie.CaptureWebPageToFile(@"C:\Documents and Settings\All Users\Favorites.png");
                ie.Close();
                ie.Dispose();
                ie = null;
            }
        }
        [Test]
        public void DoScreenshotTest()
        {
            Assert.IsNotNull(ie);
            using (TestLog.BeginSection("Go to Google, enter MbUnit as a search term and click I'm Feeling Lucky"))
            {
                ie.GoTo("http://www.google.com");
                ie.TextField(Find.ByName("q")).TypeText("MbUnit");
                ie.Button(Find.ByName("btnI")).Click();
            }
            Assert.IsTrue(ie.ContainsText("NUnit"), "Expected to find NUnit on the page.");
        }
    }
