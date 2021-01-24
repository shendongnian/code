    public static class ObjectFactory
    {
        private static Dictionary<string, object> collection = new Dictionary<string, object>();
        public static T GetObject<T>() where T : new()
        {
            string key = typeof(T).ToString();
            if (collection.ContainsKey(typeof(T).ToString()))
                return (T)collection[key];
            var instance = new T();
            collection.Add(key, instance);
                
            return instance;
        }
    }
