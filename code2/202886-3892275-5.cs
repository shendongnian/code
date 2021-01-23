    private void myDoTestMethod(string argumentOne, string argumentTwo)
    {
        IntegrationResult result = new IntegrationResult(
                                       "T-SQL returns expected results", 
                                       "Pulled 10 correct rows",
                                       "Wrong number of rows received");
        result.Execute( r=>
        {
             integrationPoint.call(argumentOne, argumentTwo);
             //do some check that correct data is present (return false if not)
             return true;
        });
     }
