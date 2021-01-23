    private static MyData ReadDataFile(string path)
    {
        int remainingAttempts = maxRetryAttempts;
        while(remainingAttempts > 0)
        {
            ...
        }
        throw new UnauthroizedAccessException();  // This exception does not contain any good debugging data.
    }  
