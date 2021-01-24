 csharp
[Binding]
public class StepsWithScenarioContext
{
    private readonly ScenarioContext scenarioContext;
    public StepsWithScenarioContext(ScenarioContext scenarioContext)
    {
        this.scenarioContext = scenarioContext;
    }
    [BeforeScenario()]
    public void GivenIPutSomethingIntoTheContext()
    {
        var title = this.scenarioContext.ScenarioInfo.Title;
        //....
    }
}
Docs are here: https://specflow.org/documentation/Parallel-Execution/ - Thread-safe ScenarioContext, FeatureContext and ScenarioStepContext
