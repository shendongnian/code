/// <summary>
/// An expectation for checking that an element is either invisible or not present on the DOM.
/// </summary>
/// <param name="locator">The locator used to find the element.</param>
/// <returns><see langword="true"/> if the element is not displayed; otherwise, <see langword="false"/>.</returns>
public static Func<IWebDriver, bool> InvisibilityOfElementLocated(By locator)
{
    return (driver) =>
    {
        try
        {
            var element = driver.FindElement(locator);
            return !element.Displayed;
        }
        catch (NoSuchElementException)
        {
            // Returns true because the element is not present in DOM. The
            // try block checks if the element is present but is invisible.
            return true;
        }
        catch (StaleElementReferenceException)
        {
            // Returns true because stale element reference implies that element
            // is no longer visible.
            return true;
        }
    };
}
If the page does not change it will not go stale, if the search finds it but it is some hidden another way where display never returns false this will never work.
You may need to write you own func for this to work with your page.
  [1]: https://github.com/DotNetSeleniumTools/DotNetSeleniumExtras/blob/dc402a5d7b9d7e78a9ce293bdb64b0b9a47685d5/src/WaitHelpers/ExpectedConditions.cs#L360
