[When(@"I click the '(.*)' button")]
public void IClickTheButton(string buttonName)
{
    driver.GetFirstButtonWithTextContaining(buttonName).Click();
}
Or rewrite your page models to encapsulate user actions on the page:
public class LoginPage
{
    private readonly IWebDriver driver;
    private IWebElement Password => driver.FindElement(By.Id("Password"));
    private IWebElement Username => driver.FindElement(By.Id("Username"));
    private IWebElement LoginButton => driver.FindElement(By.XPath("//button[contains(., 'Log In')]"));
    public LoginPage(IWebDriver driver)
    {
        this.driver = driver;
    }
    public HomePage Login(string username, string password = "test")
    {
        Username.SendKeys(username);
        Password.SendKeys(password);
        LoginButton.Click();
        var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
        wait.Until(ExpectedConditions.StalenessOf(LoginButton));
        return new HomePage(driver);
    }
}
That would mean changing your steps from the procedural style (I click this; I do that) to a more behavior driven style. For instance, it is common to "log in" using procedural steps:
cucumber
Given I am on the login page
When I enter "foo" for the "Username"
And I enter "bar" for the "Password"
And I click the "Log In" button
Instead, a behavior driven step would be a quick one-liner that delegates most of its behavior to a page model:
cucumber
Given I am logged in as "foo"
[Given(@"I am logged in as ""(.+)""")]
public GivenIAmLoggedInAs(string username)
{
    var loginPage = new LoginPage(driver);
    loginPage.LogIn(username);
}
Your cucumber steps should be a thin veneer gluing the description of application behavior in your feature files to the page models that encapsulate that behavior in a page.
