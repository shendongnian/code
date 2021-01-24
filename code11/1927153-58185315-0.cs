csharp
[Binding]
public class Hooks
{
    private IObjectContainer container;
    public Hooks(IObjectContainer container)
    {
        this.container = container;
    }
    [BeforeScenario]
    public void CreateWebDriver()
    {
        var driver = new ChromeDriver();
        container.RegisterInstanceAs<IWebDriver>(driver);
    }
    [AfterScenario]
    public void DestroyWebDriver()
    {
        var driver = container.Resolve<IWebDriver>();
        driver.Quit();
        driver.Dispose();
    }
}
And the google search page object becomes a separate class that receives a web driver object as a constructor parameter, which decouples it from SpecFlow all together.
csharp
public class GoogleSearchPage
{
    private readonly IWebDriver driver;
    private IWebElement TxtSearch => driver.FindElement(By.Name("q"));
    public GoogleSearchPage(IWebDriver driver)
    {
        this.driver = driver;
    }
    public void EnterSearchTerm(string searchTerm)
    {
        TxtSearch.SendKeys(searchTerm);
    }
}
And finally the step definition class, which is where everything gets wired together via the dependency injection framework that comes with SpecFlow:
csharp
[Binding]
public class GoogleSearchSteps
{
    private GoogleSearchPage googleSearch;
    public GoogleSearchSteps(IWebDriver driver)
    {
        googleSearch = new GoogleSearchPage(driver);
    }
    [When(@"I fill the '(.*)' field")]
    public void WhenIFillTheField(string search)
    {
        googleSearch.EnterSearchTerm(search);
    }
}
Part of the problem you have right now is the class hierarchy. You are mixing classes that should be separated, but coordinated. By separating the step definitions from the initialization of the web driver, and keeping the page object in its own class you keep the dependencies between these objects organized and limited to exactly what they need (decoupling), and yet still allow them to work together (cohesion).
