    private static object mutex = new object();
    
    protected string GetUserEmail(string accountName)
    {
        lock (mutex)
        {
            // access the dictionary
        }
    }
