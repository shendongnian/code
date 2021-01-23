    [ClassInitialize]
            public static void ClassInitialize(TestContext context) {
                drivers = new List<IWebDriver>();
                firefoxDriver = new FirefoxDriver();
                chromeDriver = new ChromeDriver(path);
                ieDriver = new InternetExplorerDriver(path);
                drivers.Add(firefoxDriver);
                drivers.Add(chromeDriver);
                drivers.Add(ieDriver);
                baseURL = "http://localhost:4444/";
            }
        [ClassCleanup]
        public static void ClassCleanup() {
            drivers.ForEach(x => x.Quit());
        }
    ..and then am able to write tests like this:
    [TestMethod]
            public void LinkClick() {
                WaitForElementByLinkText("Link");
                drivers.ForEach(x => x.FindElement(By.LinkText("Link")).Click());
                AssertIsAllTrue(x => x.PageSource.Contains("test link")); 
            }
