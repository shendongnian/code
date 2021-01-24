`
public class LoginPage
{
    private IWebDriver _driver;
    public LoginPage(IWebDriver driver)
    {
        _driver = driver;
    }
    public HomePage LoginAs(string user, string password)
    {
        // Providing user and password and clicking login button
        return new HomePage(_driver);
    }
}
`
HomePage:
`
public class HomePage
{
    private IWebDriver _driver;
    public HomePage(IWebDriver driver)
    {
        _driver = driver;
    }
    public HomePage GoTo()
    {
        // Do something
        return this;
    }
    public bool IsAt()
    {
        return true;
    }
}
`
I also advise to use [FluentAssertion][1].
With all of that, the test would look like:
`
[Test]
public void Test_Login_To_Home_Page()
{
    new LoginPage(this.driver)
        .LoginAs("user", "password")
        .GoTo()
        .IsAt()
        .Should()
        .BeTrue();
}
`
  [1]: https://fluentassertions.com/
