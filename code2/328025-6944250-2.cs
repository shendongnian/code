    static Main() 
    {
        //still wondering if the compiler might optimize this call out
        Singleton.Initialize();
        var vals = Singleton.Instance.Values;
    }
