    private void myDoTestMethod<T>(Callable<T> integrationPoint)
    {
        IntegrationResult result = new IntegrationResult();
        result.Execute( r=>
        {
             r.Description = "T-SQL returns expected results";
             r.Start();
             integrationPoint.call();
             r.Stop();
             //do some check that correct data is present
             r.ResultMessage = "Pulled 10 correct rows";
        });
     }
