    public static class Cacher
    {
        const int CacheTime = 5;  // In minutes
        static Dictionary<long, CacheItem> _cachedResults = new Dictionary<long, CacheItem>();
        public static T GetFromCache<T>(Func<T> action)
        {
            long code = action.GetHashCode();
            CacheItem item;
            if (_cachedResults.TryGetValue(code, out item))
            {
                if (item.LastUpdateTime.AddMinutes(CacheTime) >= DateTime.Now)
                {
                    return (T)_cachedResults[code].Result;
                }
            }
            T result = action();
            CacheItem newItem = new CacheItem
            {
                LastUpdateTime = DateTime.Now,
                Result = result
            };
            if (item == null)
                _cachedResults.Add(code, newItem);
            else
                _cachedResults[code] = newItem;
            return result;
        }
    }
    class CacheItem
    {
        public DateTime LastUpdateTime { get; set; }
        public object Result { get; set; }
    }
