    public static IWebElement FindElementHighlight(this IWebDriver driver, By by)
    {
        IWebElement element = driver.FindElement(by);
        if (driver is IJavaScriptExecutor)
        {
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].style.border='3px solid green'", element);
            System.Threading.Thread.Sleep(2000);
        }
        return element;
    }
