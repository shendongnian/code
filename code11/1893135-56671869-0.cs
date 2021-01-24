csharp
[Binding]
public class LoginSteps
{
    private readonly ScenarioContext scenario;
    public LoginSteps(ScenarioContext scenario)
    {
        this.scenario = scenario;
        scenario.Set("Password1", "email1");
        scenario.Set("Password2", "email2");
        ...
        scenario.Set("PasswordN", "emailN");
    }
    [When(@"I log in as '(.*)'")]
    public void WhenILogInAs(string email)
    {
        PageAction.CompleteLoginForm(email, scenario.Get(email));
    }
}
And your scenario becomes:
gherkin
Scenario: As a registered user I can log in with a valid email and password
    Given I am on the Home page
    When I click the Sign In option
    Then The login page is displayed
    When I log in as 'tester@test.co.uk'
    Then I am logged in
    And The Sign In display name is displayed in the header 'Tester McTestFace'
