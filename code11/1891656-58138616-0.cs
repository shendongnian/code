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
You can wrap other methods in the same way too. For example, you can wrap `Driver.Click();` to wait for react components to load after the action is completed. I am aware that this is just a workaround, but it will help your code look cleaner and you will not have to write lines to wait for react components after every action. Hope this helps a bit.
    
