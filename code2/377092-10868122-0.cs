    public static class MyCache2
    {
        private static IDictionary<int, string> _cache;
        private static IDictionary<int, string> _cacheClone;
        private static Object _lock;
        static MyCache2()
        {
            _cache = new Dictionary<int, string>();
            _lock = new Object();
        }
        public static string GetData(int key)
        {
            string returnValue;
            if (_cacheClone == null)
            {
                _cache.TryGetValue(key, out returnValue);
            }
            else
            {
                try
                {
                    _cacheClone.TryGetValue(key, out returnValue);
                }
                catch
                {
                    lock (_lock)
                    {
                        _cache.TryGetValue(key, out returnValue);
                    }
                }
            }
            return returnValue;
        }
        public static void AddData(int key, string data)
        {
            lock (_lock)
            {
                _cacheClone = Clone(_cache);
                if (!_cache.ContainsKey(key))
                    _cache.Add(key, data);
                _cacheClone = null;
            }
        }
    }
