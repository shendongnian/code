    [Binding]
    public class LoginSteps
    {
        private readonly IWebDriver Driver;
        private LoginPage _loginPage;
        private static string _username;
        private static string _password;
        private static string _repo;
        public LoginSteps(IWebDriver driver)
        {
            Driver = driver;
        }
        [Given(@"I am on the Login page")]
        public void GivenIAmOnTheLoginPage()
        {
            _loginPage = new LoginPage(Driver);
        }
        [Given(@"I have a good username/password combination")]
        public void GivenIHaveAGoodUsernamePasswordCombination()
        {
            _username = Nomenclature.WebClientPersonalUsername;
            _password = Nomenclature.WebClientPersonalPassword;
        }
        [Given(@"I select a repository")]
        public void GivenISelectARepository()
        {
            _repo = Nomenclature.RepoUnderTest;
        }
        [When(@"I fill out the form and submit")]
        public void WhenIFillOutTheFormAndSubmit()
        {
            _loginPage.Login(
                username: _username, 
                password: _password, 
                repo: _repo);
        }
        [Then(@"I am taken to the repo page")]
        public void ThenIAmTakenToTheRepoPage()
        {
            Assert.AreEqual(
                expected: _repo,
                actual: Driver.Title);
            HelperMethods.Logout(Driver);
        }
    }
