csharp
public void WaitForElement(IWebElement element, int timeout = 2)
{
    WebDriverWait wait = new WebDriverWait(webDriver, TimeSpan.FromMinutes(timeout));
    wait.IgnoreExceptionTypes(typeof(NoSuchElementException));
    wait.IgnoreExceptionTypes(typeof(StaleElementReferenceException));
    wait.Until<bool>(driver =>
    {
        try
        {
            return element.Displayed;
        }
        catch (Exception)
        {
            return false;
        }
    });
}
