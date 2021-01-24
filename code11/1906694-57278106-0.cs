public class TestSetup : IDisposable
{
   protected readonly IWebDriver Driver;
   public TestSetup()
   {
       var options = new ChromeOptions();
       Driver = new RemoteWebDriver(new Uri("http://localhost:4444/wd/hub"), options.ToCapabilities(), TimeSpan.FromSeconds(10));
       Driver.Manage().Window.Maximize();
       Driver.Navigate().GoToUrl("https://google.com");
   }
   public void Dispose() 
   {
       Driver.Close();
       Driver.Quit();
   }
}
