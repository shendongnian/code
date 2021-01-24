var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
var element = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("your xpath here")));
Assert.NotNull(element);
The assert format will differ based on your framework. That one is from xUnit.
Note: the package containing ExpectedConditions is not maintained, but they are pretty simple, and can be copied into your code, or own package, if you are worried about it. 
public static Func<IWebDriver, IWebElement> ElementIsVisible(By locator)
{
    return (driver) =>
    {
        try
        {
            return ElementIfVisible(driver.FindElement(locator));
        }
        catch (StaleElementReferenceException)
        {
            return null;
        }
    };
}
private static IWebElement ElementIfVisible(IWebElement element)
{
    return element.Displayed ? element : null;
}
