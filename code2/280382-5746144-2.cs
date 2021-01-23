    class FooMultiton
    {
        private static readonly Dictionary<object, FooMultiton> _instances = new Dictionary<object, FooMultiton>();
 
        private FooMultiton() {}
 
        public static FooMultiton GetInstance(object key)
        {
            lock (_instances)
            {   
                FooMultiton instance;
                if (!_instances.TryGetValue(key, out instance))
                {
                    instance = new FooMultiton();
                    _instances.Add(key, instance);
                }
            }
            return instance;
        }
    }
