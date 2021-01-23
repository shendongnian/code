        public IWebDriver driver { get; private set; };
        [TestFixtureSetUp]
        public void TestFixtureSetup()
        {
            driver = new FirefoxDriver();
            driver.Navigate().GoToUrl("http://www.google.com/");
        }
        [TestFixtureTearDown]
        public void TestFixtureTearDown()
        {
             driver.Quit();
        }
