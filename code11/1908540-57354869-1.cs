csharp
public class ChromeDriverFixture
{
    public ChromeDriverFixture()
    {
        Driver = ...
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
    // Test method using _fixture.Driver
}
