csharp
[Binding]
public class SeleniumSpecFlowHooks
{
    private readonly IObjectContainer container;
    public SeleniumSpecFlowHooks(IObjectContainer container)
    {
        this.container = container;
    }
    [BeforeStep]
    public void CreateWebDriver()
    {
        // Create and configure a concrete instance of IWebDriver
        IWebDriver driver = new FirefoxDriver(...)
        {
            ...
        };
        // Make this instance available to all other step definitions
        container.RegisterInstance(driver);
    }
    [AfterStep]
    public void DestroyWebDriver()
    {
        IWebDriver driver = container.Resolve<IWebDriver>();
        driver.Close();
        driver.Dispose();
    }
}
Your step definition classes should not be initializing the web driver. Just declare an `IWebDriver` argument in their constructors.
Base class:
csharp
[Binding]
public class SpecflowBaseTest : TechTalk.SpecFlow.Steps
{
    protected IWebDriver Driver { get; }
    protected LoginPage LoginPage { get; }
    public SpecflowBaseTest(IWebDriver driver)
    {
        Driver = driver;
        LoginPage = new LoginPage(driver);
    }
    public void NavigateToURL(string URL)
    {
        Driver.Navigate().GoToUrl(URL);
    }
}
Child class:
csharp
[Binding, Parallelizable]
public class LoginSteps : SpecflowBaseTest
{
    [Given(@"I navigate to (.*)")]
    public void GivenINavigateToHttpsCompany_Com(string URL)
    {
        NavigateToURL(URL);
    }
    [Given(@"I enter bw_(.*) and (.*)")]
    public void GivenIEnterBw_Valid_UserAnd(string Username, string Password)
    {
        LoginPage.Login(Username, Password);
    }
    [Then(@"I am logged in as bw_valid_user")]
    public void ThenIAmLoggedInAsBw_Valid_User()
    {
        //LoginPage.
    }
}
