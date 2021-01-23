    private static readonly ObjectIdGenerator oidg = new ObjectIdGenerator();
    
    public string GetContent(Func<string, bool> isValid)
    {
        bool firstTime;
    
        oidg.GetId(isValid, out firstTime);
    
        if (!firstTime)
        {
            ...
        }
    }
