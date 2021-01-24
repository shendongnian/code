c#
public class NoReloadVerificationContext : IDisposable
{
    private readonly IWebElement bodyElement;
    public NoReloadVerificationContext(IWebDriver webDriver)
    {
        this.bodyElement = webDriver.FindElement(By.TagName("body"));
    }
    public void Dispose() => Assert.True(this.bodyElement.Enabled);
}
I've seen such approach in some software projectes that provides API - for example creating a context that can make operation without be signed as admin until it's disposed.
An example usage:
c#
// This block asserts that no reload occurred after executing operation inside
// Else it throws an exception - which is OK for me. 
using (new NoReloadVerificationContext(driver))
{
    // this will submit the form and cause page reload because of missing client vlidations
    driver.FindElementByCssSelector("form input[type=submit]").Click();
} // The exception will occur here.
I don't know whether this is the best solution, but it will work in most cases (not only in forms)
The other approach was to get the value of `__RequestVerificationToken` inside my form (MVC generates it at the end of each form), then perform some actions, after that get the value again and compare with the old one. But this will work only for form submits. 
