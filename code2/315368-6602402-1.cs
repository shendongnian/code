    // Make the property blocking
    public IEnumarable MyList
    {
        get
        {
             // Block via .Result
             return MyAsyncMethod().Result;
        }
    }
