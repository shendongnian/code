    [SetUpFixture]
    public class TestSetup
    {
        [OneTimeSetUp]
        public void Setup()
        {
            Console.WriteLine("Login in");
        }
        [OneTimeTearDown]
        public void Teardown()
        {
            Console.WriteLine("Login out");
        }
    }
