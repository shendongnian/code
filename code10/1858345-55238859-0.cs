    public sealed class Hooks
    {        
        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            FeatureContextWrapper myWrapper = new FeatureContextWrapper();
            myWrapper.BrowserSession = BrowserFactory.GetBrowser();
        }
    }
