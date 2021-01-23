    private void myDoTestMethod(string argumentOne, string argumentTwo)
    {
        IntegrationResult result = new IntegrationResult();
        result.Execute( r=>
        {
             r.Description = "T-SQL returns expected results";
             r.Start();
             integrationPoint.call(argumentOne, argumentTwo);
             r.Stop();
             //do some check that correct data is present
             r.ResultMessage = "Pulled 10 correct rows";
        });
     }
