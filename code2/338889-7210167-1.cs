    static void M(Func<int> f) { }
    static void M(Func<string> f) { }
    static void M(Func<object> f) { }
    
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
