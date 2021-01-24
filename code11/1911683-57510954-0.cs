csharp
public class LoginPage
{ 
    public IWebDriver driver;
    public LoginPage(IWebDriver _driver)
    {
        this.driver = _driver;
    }
    private IWebElement Username => driver.FindElement(By.Id("username"));
    private IWebElement Password => driver.FindElement(By.Id("pass"));
    private IWebElement LoginButton => driver.FindElement(By.XPath("//button[contains(., 'Login']"));
    public void LogIn(string username, string password)
    {
        Username.SendKeys(username);
        Password.SendKeys(password);
        LoginButton.Click();
    }
}
And a sample step definition file:
csharp
[Binding]
public class StepDefinition1
{
    private IWebDriver driver;
    private LoginPage loginPage;
    public StepDefinition1(IWebDriver _driver)
    {
        driver = _driver;
        loginPage = new LoginPage(driver);
    }
    [When(@"I log in")]
    public void WhenIEnterData()
    {
        loginPage.LogIn("test", "test");
    }
}
Now the code that interacts with the web browser using the Selenium API is centralized in their own classes, giving you an easy way to reuse that code. It also allows you to create classes that can handle the intricate details of interacting with the web page, so this complexity is not spread out over your step definitions.
No need for inheritance at all. Composition will be simpler and easier to reuse code.
