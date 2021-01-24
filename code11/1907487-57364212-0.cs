`
private ChromeOptions GetChromeOptions()
{
    var options = new ChromeOptions();
    
    ProfilePath = Path.Combine(AppContext.BaseDirectory, "tmp", Guid.NewGuid().ToString());
    DownloadPath = Path.Combine(ProfilePath, "Downloads");
    if (!Directory.Exists(DownloadPath))
    {
        Directory.CreateDirectory(DownloadPath);
    }
    options.AddUserProfilePreference("download.default_directory", DownloadPath);
    //--lang=en-US,en headless does not define a language by default 
    options.AddArguments("--incognito", "--lang=en-US,en", $@"--user-data-dir={ProfilePath}");
    return options;
}
`
I'm using xUnit to spawn dozens of headless chromes tests and I've not ever seen the dispose close all of the instances. The only difference I can think of is that I am spawning each with their own profile.
I would suggest using the setup and teardown of your testing framework onto a base class to handle the setup and teardown for all tests.
`
public class PageLoad: IDisposable
{
    private IWebDriver _driver;
    public void PageLoad()
    {
        _driver = new ChromeDriver();
    }
    [Fact]
    public void PageLoadTest()
    {
        _driver.Navigate().GoToUrl("http://google.com");
        Assert.True(_driver.FindElement(By.XPath("//*[@id='hplogo']")).Displayed);
    }
    public void Dispose()
    {
        _driver.Dispose();
    }
}
`
You can also wrap the driver in a using statement
`
using (var driver = new ChromeDriver())
{
    driver.Navigate().GoToUrl("http://google.com");
    Assert.True(_driver.FindElement(By.XPath("//*[@id='hplogo']")).Displayed);
}
`
