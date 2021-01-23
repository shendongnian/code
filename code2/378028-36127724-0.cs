    [Binding]
    public class StepsWithScenarioContext : Steps
    {
        [Given(@"I put something into the context")]
        public void GivenIPutSomethingIntoTheContext()
        {
            this.ScenarioContext.Set("test-value", "test-key");
        }
    }
