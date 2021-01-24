csharp
public class ChromeDriverFixture
{
    public ChromeDriverFixture()
    {
        Driver = new ChromeDriver(@"C:\Path\To\ChromeDriver");
        Driver.Manage().Window.Maximize();
    }
    public IWebDriver Driver { get; }
}
public class UnitTest1 : IClassFixture<ChromeDriverFixture>
{
    private ChromeDriverFixture _fixture;
    public UnitTest1(ChromeDriverFixture fixture)
    {
        _fixture = fixture;
    }
    [Fact]
    public void Launch_Amazon_WithSearching()
    {
        const string amazonUrl = "https://www.amazon.in/";
        _fixture.Driver.Navigate().GoToUrl(amazonUrl);
        // ...
    }
}
