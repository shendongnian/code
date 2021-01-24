[TestFixture]
public class TestSetup
{
   private ThreadLocal<IWebDriver> _driver;
   protected IWebDriver Driver => _driver.Value;
   // Test Setup, every test starts with this method
   [SetUp]
   public void StartTest()        
   {
       var options = new ChromeOptions();
       _driver = new ThreadLocal<IWebDriver>(() => new RemoteWebDriver(new Uri("http://localhost:4444/wd/hub"), options.ToCapabilities(), TimeSpan.FromSeconds(10)));
       Driver.Manage().Window.Maximize();
       Driver.Navigate().GoToUrl("https://google.com");
   }
   // Test Tear Down, every test ends with this method
   [TearDown]
   public void QuitTest()
   {
       Driver.Close();
       Driver.Quit();
       _driver.Dispose();
   }
}
This may impact performance because of `TheadLocal`. I'm not sure.
