    [TestFixture]
    public class MedappzTests
    {
        private IE ie;
        [SetUp]
        public void DoTestSetup()
        {
            ie = new IE();
        }
        [TearDown]
        public void DoTestTeardown()
        {
            if (ie != null)
            {
                ie.Close();
                ie.Dispose();
                ie = null;
            }
        }
        [Test]
        public void NavigateToMedappz()
        {
            //...
        }
        [Test]
        public void LoginToMedappz()
        {
            this.NavigateToMedappz();
            //...
            //Here I'm assuming that if you've successfully logged in then the login button should no longer exist
            Assert.IsFalse(btnLogin.Exists, "Login button exists");
        }
