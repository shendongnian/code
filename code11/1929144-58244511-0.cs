 csharp
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
namespace AutomationTest
{
   public class BaseLocator
   {
       public static RemoteWebDriver driver = new ChromeDriver();
	   //public static WebDriverWait wait; //TODO: Initialize variable as above
   
	   public IWebElement SearchBox => driver.FindElementByCssSelector("#twotabsearchtextbox");
       public IWebElement SearchButton => driver.FindElementByCssSelector("span#nav-search-submit-text + input");
       public IWebElement GoToShoppingButton => driver.FindElementByCssSelector("#nav-cart-count");
       public IWebElement GoToYourAmazonButton => driver.FindElementByCssSelector("a#nav-your-amazon");
   }
}
while this example initializes it via the default constructor method:
 csharp
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
namespace AutomationTest
{
   public class BaseLocator
   {
       public static RemoteWebDriver driver;
	   //public static WebDriverWait wait;
	   
	   public BaseLocator()
	   {
	       driver = new ChromeDriver();
	   }
   
	   public IWebElement SearchBox => driver.FindElementByCssSelector("#twotabsearchtextbox");
       public IWebElement SearchButton => driver.FindElementByCssSelector("span#nav-search-submit-text + input");
       public IWebElement GoToShoppingButton => driver.FindElementByCssSelector("#nav-cart-count");
       public IWebElement GoToYourAmazonButton => driver.FindElementByCssSelector("a#nav-your-amazon");
   }
}
I'm unfamiliar with Selenium, so I approached this from a C# language angle- but it should get you down the track.
recommended reading on constructors: https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/using-constructors
