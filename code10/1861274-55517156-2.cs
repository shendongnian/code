    [Binding]
    public class CustomerManagementSteps
    {
    	public readonly string token;
    	public CustomerManagementSteps()
    	{
    		token= ScenarioContext.Current["Token"].ToString();
    	}
    
    	[Given(@"I Get the customer details""(.*)""")]
    	public void WhenIGetTheCustomerDetails(string endpoint)
    	{
    		//Now the Token variable holds the token value from the scenario context and It can be used in the subsequent steps       
    	}
    }
