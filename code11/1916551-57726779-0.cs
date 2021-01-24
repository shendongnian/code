csharp
var timeToWait = TimeSpan.FromSeconds(1);
var wait = new WebDriverWait(driver, timeToWait);
wait.Until(d => page.ToastTitle == "Ok");
// Do the next thing in your test
If the toast title is not `"Ok"` after one second, Selenium throws a `WebDriverTimeoutException`, which should fail the test.
An extension method is pretty easy to write and is really handy to have:
csharp
public static class WebDriverExtensions
{
    public static void WaitUntil<TResult>(this IWebDriver driver, Func<IWebDriver, TResult> condition, int secondsToWait = 30)
    {
        var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(secondsToWait));
        wait.Until(condition);
    }
}
This makes waiting for something a little more intuitive to use:
csharp
driver.WaitUntil(d => page.ToastTitle = "Ok");
// Perform the next step in your test.
