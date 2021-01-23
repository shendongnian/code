        public static class Cache<T> 
        { 
            public static readonly Func<T> Get = GetImpl();
            static Func<T> GetImpl()
            {
                //some expensive operation here, and return a compiled delegate
            }
        }
    instead of 
        public static class Cache<T> 
        {
            public static T Get()
            {
                //build expression, compile delegate and invoke the delegate
            }
        }
     In the first case when you call `Get`, `GetImpl` is executed only once, where as in the second case, (expensive) `Get` will be called every time.
