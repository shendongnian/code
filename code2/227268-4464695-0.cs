    public void SendName<T>(T properties)
        where T : IProperties    // types passed in must derive from IProperties
    {
        var name = properties.Name;
        // ...
    }
    
    //...
    
    // Usage:
    base.SendName<IProperties>(this);
