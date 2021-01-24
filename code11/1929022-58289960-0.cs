    using Xunit;                   // Testing framework.  NuGet package
    using OpenQA.Selenium.Firefox; // Driver for Firefox
    using Xunit.Priority;          // NuGet add-on to Xunit that allows you to order the tests
    using OpenQA.Selenium;         // NuGet package 
    using System.Diagnostics;      // Can Debug.Print when running tests in debug mode
    namespace Test_MyWebPage
    {
        [TestCaseOrderer(PriorityOrderer.Name, PriorityOrderer.Assembly)] // Set up ordering
        public class Test_BasicLogin : IDisposable
        {
           public static IWebDriver driver = new FirefoxDriver(@"path\to\geckodriver");
           // Here be the tests...
           [Fact, Priority(0)]
           public void Test_LaunchWebsite()
           {
               // Arrange
               var url = "https://yourserver.yourdomain/yourvirtualdir";
               // Act
               // Sets browser to maximized, allows 1 minute for the page to
               // intially load, and an implicit time out of 1 minute for elements
               // on the page to render.
               driver.Manage().Window.Maximize();
               driver.Manage().Timeouts().PageLoad = new TimeSpan(0, 1, 0);
               driver.Manage().Timeouts().ImplicitWait = new TimeSpan(0, 1, 0);
        
               driver.url = url;  // Launches the browser and opens the page
               /* Assuming your page has a login prompt 
               /* we'll try to locate this element 
               /* and perform an assertion to test that the page comes up
               /* and displays a login prompt */
               var UserNamePrompt = driver.FindElement(By.Id("userLogin_txtUserName"));   
               // Assert
               Assert.NotNull(UserNamePrompt); // Bombs if the prompt wasn't found.
               Debug.Print("Found User Name Prompt successfully.");
            }
            public void Dispose()
            {
               // Properly close the browser when the tests are done
                try
                {
                    driver.Quit();
                }
                catch (Exception ex)
                {
                    Debug.WriteLine($"Error disposing driver: {ex.Message}");
                }
            }
        }
    }
