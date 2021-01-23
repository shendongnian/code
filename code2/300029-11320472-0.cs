    public static IWebElement FindElementByJs(this IWebDriver driver, string jsCommand)
    {
        return (IWebElement)((IJavaScriptExecutor)driver).ExecuteScript(jsCommand);
    }
    public static IWebElement FindElementByJsWithWait(this IWebDriver driver, string jsCommand, int timeoutInSeconds)
    {
        if (timeoutInSeconds > 0)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
            wait.Until(d => d.FindElementByJs(jsCommand));
        }
        return driver.FindElementByJs(jsCommand);
    }
    public static IWebElement FindElementByJsWithWait(this IWebDriver driver, string jsCommand)
    {
        return FindElementByJsWithWait(driver, jsCommand, s_PageWaitSeconds);
    }
