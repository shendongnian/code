`
public static class WebDriverExtensions()
{
    public static void WaitForComponents(this IWebDriver driver)
    {
        var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        wait.Until(d => js.ExecuteScript("return window.document.hasHomeMounted"));
    }
    public static void GoToUrl(this IWebDriver driver, string url)
    {
        driver.Navigate().GoToUrl(url);
        driver.WaitForComponents();
    }
}
`
Then, your test case will look like:
`
using WebDriverExtensions;
using (IWebDriver driver = new ChromeDriver())
{
    IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
    driver.GoToUrl($"{Properties.Settings.Default.ApplicationUrl}/Dashboard");
    //Can do next thing....
    Assert.IsTrue(true);
}
`
If the component you are checking is constantly changing, i.e. `hasHomeMounted` only works on the Home page, the solution is a little uglier. You could try something that takes a component name as a parameter to check if it is mounted:
`
    public static void WaitForComponent(this IWebDriver driver, string componentName)
    {
        var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        wait.Until(d => js.ExecuteScript($"return window.document.has{componentName}Mounted"));
    }
`
As I mentioned, there is no catch-all way to accomplish this, and using `Thread.Sleep()` everywhere is not advisable. Your solution which checks the react component mounting is a good solution.
If you do not like the above solution, here's what I specifically used to handle most of my React UI testing:
`
public static void WaitAndClick(this IWebDriver driver, By by)
{
     var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
     wait.Until(ExpectedConditions.ElementToBeClickable(by));
     driver.FindElement(by).Click();
}
`
My issues with automating React UI involved elements taking too long to load. Most of the page would load, but the component I was trying to click would not exist sometimes. So I wrapped `Click()` in a `WaitAndClick()` method, to ensure the element is clickable before I try to perform the click. This worked for most of my cases.
    
