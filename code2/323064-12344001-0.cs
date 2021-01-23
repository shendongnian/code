    [SetUpFixture]
    public class SetupFixtureClass
    {
        [SetUp]
        public void StartTesting()
        {
            System.Diagnostics.Debugger.Launch();
        }
    }
