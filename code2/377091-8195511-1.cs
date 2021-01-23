    public static class MyCache2
    {
        private static IDictionary<int, string> _cache;
        static MyCache2()
        {
            _cache = new Dictionary<int, string>();
        }
        public static string GetData(int key)
        {
            string returnValue;
            _cache.TryGetValue(key, out returnValue);
            return returnValue;
        }
        public static void AddData(int key, string data)
        {
            IDictionary<int, string> clone = Clone(_cache);
            if (!clone.ContainsKey(key))
                clone.Add(key, data);
            Interlocked.Exchange(ref _cache, clone);
        }
    }
