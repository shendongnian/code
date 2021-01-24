public class PageWait
{
  public  IWebElement waitForPageUntilElementIsVisible(By locator,int maxseconds)
    {
       return new  WebDriverWait(driver, TimeSpan.FromSeconds(maxseconds))
            .Until(ExpectedConditions.ElementExists((locator)));
    }
}
class Program { 
public IWebDriver driver;
    static void Main(string[] args)
    {
        IWebDriver driver = new ChromeDriver();
        driver.Navigate().GoToUrl("https://www.mail.com/int/");
        IWebElement login = driver.FindElement(By.Id("login-button"));
        login.Click();
        IWebElement email = driver.FindElement(By.Id("login-email"));
        new PageWait().waitForPageUntilElementIsVisible(By.Id("login-email"), 5);
        email.SendKeys("CarlosdanielGrossen95@mail.com");
    }
}
