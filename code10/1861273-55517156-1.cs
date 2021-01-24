    [Given(@"I Get the customer details""(.*)""")]
    public void WhenIGetTheCustomerDetails(string endpoint)
    {
       if(ScenarioContext.Current.ContainsKey("Token"))
       {
    	   var token = ScenarioContext.Current["Token"].ToString();
    	   //Now the Token variable holds the token value from the scenario context and It can be used in the subsequent steps
       }
       else
    	{
    		Assert.Fail("Unable to get the Token from the Scenario Context");
    	}
    }
