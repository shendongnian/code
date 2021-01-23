    public static class TypeHandler // note: get rid of generic T parameter
    {
        delegate void ProcessDelegate(ref object obj); // again, not generic
        
        static Dictionary<Type, ProcessDelegate> processors = new Dictionary<Type, ProcessDelegate>()
        {
            { typeof(string), (ref object obj) => { obj = "Hello, world!"; } }
            // etc.
        };
    
        public static void Process(ref object obj)
        {
            processors[obj.GetType()].Invoke(ref obj);
        }
    }
