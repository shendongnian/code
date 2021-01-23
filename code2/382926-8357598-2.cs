    static class TestClass
    {
        static Dictionary<Type, object> factories = new Dictionary<Type, object>()
        {
            { typeof(string), "Hello, world!" }
            // etc.
        };
    
        static void Test1(ref object obj)
        {
            obj = factories[obj.GetType()];
        }
    }
