    using System.IO;
    using System.Text;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Chrome;
    using OpenQA.Selenium.Support.UI;
    
    namespace WebDriverTest
    {
        class Program
        {
            static void Main(string[] args)
            {
                // Initialize the Chrome Driver
                using (var driver = new ChromeDriver())
                {
                    // Go to the home page
                    driver.Navigate().GoToUrl("https://portal.vastuugroup.fi/api/general/external-redirects?lang=fi&amp;sp_route=/");
                       driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);
                    // Get the page elements
                    var userNameField = driver.FindElementById("loginForm:username");
                    var userPasswordField = driver.FindElementById("loginForm:password");
                    var loginButton = driver.FindElementById("loginForm:loginButton");
    
                    // Type user name and password
                    userNameField.SendKeys("username");
                    userPasswordField.SendKeys("password");
    
                    // and click the login button
                    loginButton.Click();
    				
    			}
            }
        }
    }
