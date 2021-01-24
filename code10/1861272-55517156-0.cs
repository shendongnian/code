    public class CommonHooks
    {
    	[BeforeScenario]
    	public static void Setup()
    	{
    		// Add Token Generation Step
    		var adminToken = "<Generated Token>";
    		ScenarioContext.Current["Token"] = adminToken;
    	}
    }
