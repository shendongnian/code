     private string Name
     {
       get
       {
          return ScenarioContext.Current["Name"].ToString();
       }
       set
       {
          ScenarioContext.Current["Name"] = value;
       }
            }
    
    [Given(@"User had specified name (.*) description (.*) in create application request")]
            public void GivenUserHadSpecifiedNameDummyApplicationDescriptionTestdescriptionInCreateApplicationRequest(string name, string description)
            {
                // store the name
                this.Name = name;
            }
    
    
            [Then(@"User should get an error code (.*) in the createApplication response with error message as (.*)")]
            public void ThenUserShouldGetAnErrorCodeInTheCreateApplicationResponseWithErrorMessageAsApplicationNamedNameAlreadyExistsForAGivenTenant(int errorCode, string errorMessage)
            {
                // retrieve the name and use
                var expected = errorMessage.Replace("${name}", $"'{this.Name}'");
                //Application named 'DummyApplication' already exists for a given tenant
    
            }
