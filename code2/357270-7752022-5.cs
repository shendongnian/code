    using WatiN.Core;
    using NUnit.Framework;
    namespace ConsoleApplication1
    {
        [TestFixture]
        public class AutomatedTests
        {
            [Test]
            public void DoGoogleTest()
            {
                using (IE browser = new IE())
                {
                    browser.GoTo("www.google.co.uk");
                    Div logoDiv = browser.Div("hplogo");
                    Assert.IsTrue(logoDiv.Exists, "Logo div does not exist");
                    TextField searchText = browser.TextField("lst-ib");
                    Assert.IsTrue(searchText.Exists, "Search text field does not exist");
                    Button searchBtn = browser.Button(Find.ByName("btnK"));
                    Assert.IsTrue(searchBtn.Exists, "Search button does not exist");
                    Button nonExistantButton = browser.Button("garbagegarbagegarbage");
                    // This will cause the test to fail because the link doesn't (shouldn't!) exist.
                    // Comment it out and the test should pass
                    Assert.IsTrue(nonExistantButton.Exists, "Non-existant button does not exist");
                }
            }
        }
    }
