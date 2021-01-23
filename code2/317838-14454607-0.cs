    public static class SeleniumDriverExtensions
    {
        public static void GoToUrl(this IWebDriver driver, string url, By elementToWaitFor = null)
        {
            driver.Navigate().GoToUrl(url);
            driver.WaitUntillElementIsPresent(elementToWaitFor ?? By.CssSelector("div.body"));
        }
        
        public static void WaitUntillElementIsPresent(this IWebDriver driver, By by)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(d => d.IsElementPresent(by) && d.FindElement(by).Displayed);
        }
              .....
    }
