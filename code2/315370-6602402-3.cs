    // Make the property blocking
    public IEnumerable MyList
    {
        get
        {
             // Block via .Result
             return MyAsyncMethod().Result;
        }
    }
