        private void YourTest()
        {
            IWebDriver browserDriver = new FirefoxDriver();
            browserDriver.Navigate().GoToUrl(pageUrl);
            List<IWebElement> listOfLinks = browserDriver.FindElements(By.TagName("a")).ToList();
            for (int i = 0; i <= listOfLinks.Count-1; i++ )
            {
                List<IWebElement> linksToClick = browserDriver.FindElements(By.TagName("a")).ToList();
                linksToClick[i].Click();
            }
        }
