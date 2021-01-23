    public static string GetTheValue(Foo foo)
    {
        int keyCode = ...
    
        string theValue = _cd.GetOrAdd(keyCode, (key => FooFactory(foo))); //key is not used in the factory
    
        return theValue;
    }
