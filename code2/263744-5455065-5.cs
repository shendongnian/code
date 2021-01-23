    public static class Cacher
    {
        const int CacheTime = 5;  // In minutes
        static Dictionary<long, CacheItem> _cachedResults = new Dictionary<long, CacheItem>();
        public static T GetFromCache<T>(Func<T> action)
        {
            long code = action.GetHashCode();
            if (!_cachedResults.ContainsKey(code))
            {
                lock (_cachedResults)
                {
                    if (!_cachedResults.ContainsKey(code))
                    {
                        _cachedResults.Add(code, new CacheItem { LastUpdateTime = DateTime.MinValue });
                    }
                }
            }
            CacheItem item = _cachedResults[code];
            if (item.LastUpdateTime.AddMinutes(CacheTime) >= DateTime.Now)
            {
                return (T)item.Result;
            }
            T result = action();
            _cachedResults[code] = new CacheItem
            {
                LastUpdateTime = DateTime.Now,
                Result = result
            };
            return result;
        }
    }
    class CacheItem
    {
        public DateTime LastUpdateTime { get; set; }
        public object Result { get; set; }
    }
