csharp
[Binding]
public class LoginSteps : SpecflowBaseTest
{
    private LoginPage LoginPage { get; }
    public LoginSteps(IWebDriver driver) : base(driver)
    {
        LoginPage = new LoginPage(driver);
    }
}
