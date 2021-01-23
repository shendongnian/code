    static class TestClass
    {
        static Dictionary<Type, Func<object>> factories = new Dictionary<Type, Func<object>>()
        {
            { typeof(string), () => "Hello, world!" }
            // etc.
        };
    
        static void Test1(ref object obj)
        {
            obj = factories[obj.GetType()].Invoke();
        }
    }
