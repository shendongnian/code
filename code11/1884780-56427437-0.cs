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
