csharp
        public static IWebElement waitForPageUntilElementIsVisible(By locator,int maxseconds)
    {
       return new  WebDriverWait(driver, TimeSpan.FromSeconds(maxseconds))
            .Until(ExpectedConditions.ElementExists((locator)));
    }
