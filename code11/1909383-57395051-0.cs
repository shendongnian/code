csharp
IWebElement usernameField = driver.FindElement(By.CssSelector("input[name = 'username']");
usernameField.SendKeys("ciu4clj");
Similarly, I bet the password field has "password" as its name:
csharp
IWebElement passwordField = driver.FindElement(By.CssSelector("input[name = 'password']");
passwordField.SendKeys("...");
You can take this one step further and create a Page Object for the login page:
csharp
public class LoginPage
{
    private readonly IWebDriver driver;
    private IWebElement PasswordField => driver.FindElement(By.CssSelector("input[name = 'password']"));
    private IWebElement UsernameField => driver.FindElement(By.CssSelector("input[name = 'username']"));
    // You might need to change this XPath to "input[@type = 'submit' and contains(., 'Login')]""
    private IWebElement LoginButton => driver.FindElement(By.XPath("//button[contains(., 'Login')]"));
    public LoginPage(IWebDriver driver)
    {
        this.driver = driver;
    }
    public void Login(string username, string password)
    {
        UsernameField.SendKeys(username);
        PasswordField.SendKeys(password);
        LoginButton.Click();
    }
}
