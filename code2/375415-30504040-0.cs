    public class Browser
        {
            static IWebDriver webDriver = new FirefoxDriver();
            //static IWebDriver webDriver = new ChromeDriver();
            //InternetExplorerOptions  options = new InternetExplorerOptions(); 
            //static IWebDriver webDriver = new InternetExplorerDriver(@"C:\Program Files\Selenium\");
            public static void GoTo(string url)
            {
                //webDriver.Manage().Timeouts().ImplicitlyWait(new TimeSpan(0, 0, 5));
                webDriver.Url = url;
            }
            public static ISearchContext Driver
            {
                get { return webDriver; }
            }
            public static void Teardown()
            {
                webDriver.Quit();
            }   
            public static void MaximizeWindow()
            {
                webDriver.Manage().Window.Maximize();
            }
