        private void YourTest()
        {
            IWebDriver browserDriver = new FirefoxDriver();
            browserDriver.Navigate().GoToUrl(pageUrl);
            int linkCount= browserDriver.FindElements(By.TagName("a")).Count;
            for (int i = 0; i <= linkCount-1; i++ )
            {
                List<IWebElement> linksToClick = browserDriver.FindElements(By.TagName("a")).ToList();
                linksToClick[i].Click();
            }
        }
