    [Binding]
    public class MyScenario
    {
        private readonly ScenarioContext scenarioContext;
    
        public MyScenario(ScenarioContext scenarioContext)
        {
            this.scenarioContext = scenarioContext;
        }
    
        [Given(@"I put something in the shared context")]
        public void GivenIPutSomethingInTheSharedContext()
        {
            //Add to scenarioContext
        }
        [Given(@"I read something in the shared context")]
        public void GivenIReadSomethingInTheSharedContext()
        {
            //Get from scenarioContext
        }
    }
