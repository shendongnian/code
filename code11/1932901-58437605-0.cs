[Binding]
public class WebDriverHooks
{
    private readonly IObjectContainer container;
    public WebDriverHooks(IObjectContainer container)
    {
        this.container = container;
    }
    [BeforeScenario]
    public void CreateWebDriver()
    {
        // or new FirefoxDriver or new WhateverDriver as long as it implements
        // the IWebDriver interface
        ChromeDriver driver = new ChromeDriver();
        // Make 'driver' available for DI
        container.RegisterInstanceAs<IWebDriver>(driver);
    }
    [AfterScenario]
    public void DestroyWebDriver()
    {
        var driver = container.Resolve<IWebDriver>();
        if (driver != null)
        {
            driver.Quit();
            driver.Dispose();
        }
    }
}
And a sample step definition file:
[Binding]
public class LoginSteps
{
    private readonly IWebDriver driver;
    private readonly LoginPage loginPage;
    public LoginSteps(IWebDriver driver)
    {
        // Assign 'driver' to private field or use it to initialize a page object
        this.driver = driver;
        // Initialize Selenium page object
        this.loginPage = new LoginPage(driver);
    }
    [When(@"I go to the login page")]
    public void WhenIGoToTheLoginPage()
    {
        // Use 'driver' in step definition
        driver.FindElement(By.LinkText("Sign In")).Click();
    }
    [When(@"I log in")]
    public void WhenILogIn()
    {
        // Use Selenium page object in step definition
        loginPage.LogIn("testUser", "testPassword");
    }
}
This not only allows you to share web driver instances across step definition files, but it centralizes the logic of creating and disposing of these objects, and brings you one step closer allowing parallel tests execution.
  [1]: https://stackoverflow.com/q/58390535/3092298
