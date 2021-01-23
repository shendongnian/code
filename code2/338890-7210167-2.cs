    static void M(Func<int> f) { }
    static void M(Func<string> f) { }
    static void M(Func<object> f) { } // could be also declared like dynamic here, works by the way
    
    static object DynamicObject()
    {
        return new object();
    }
    
    static void Test()
    {
        M(() => 0);
        M(() => "");
        M(() => DynamicObject());
    }
