    using System.Linq;
    using OpenQA.Selenium.Chrome;
    using Scripting;
    using System.IO;
    
    namespace WebDriverTest
    {
        class Program
        {
            static void Main(string[] args)
            {
    
                var chromeOptions = new ChromeOptions();
                chromeOptions.AddArguments("headless");
    
                // Initialize the Chrome Driver
                using (var driver = new ChromeDriver(chromeOptions))
                {
                    // Go to the home page
                    driver.Navigate().GoToUrl("xxx.com");
                    driver.Manage().Timeouts().ImplicitWait = System.TimeSpan.FromSeconds(15);
                    // Get the page elements
                    var userNameField = driver.FindElementById("loginForm:username");
                    var userPasswordField = driver.FindElementById("loginForm:password");
                    var loginButton = driver.FindElementById("loginForm:loginButton");
    
                    // Type user name and password
                    userNameField.SendKeys("username");
                    userPasswordField.SendKeys("password");
    
                    // and click the login button
                    loginButton.Click();
    
                    // Extract the text and save it into result.txt
                    // var result = driver.FindElementByXPath("//div[@id='case_login']/h3").Text;
                    // File.WriteAllText("result.txt", result);
    
                    // Take a screenshot and save it into screen.png
                    driver.GetScreenshot().SaveAsFile(@"screen.png", OpenQA.Selenium.ScreenshotImageFormat.Png);
               }
            }
    
        }
    }
