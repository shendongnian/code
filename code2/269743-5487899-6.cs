    private static MyData ReadDataFile(string path)
    {
        int remainingAttempts = maxRetryAttempts;
        while(remainingAttempts >0)  //  Non-constant expression.
        {
            ...
        }
        throw new UnauthroizedAccessException();  // This exception does not contain any good debugging data.
    }  
