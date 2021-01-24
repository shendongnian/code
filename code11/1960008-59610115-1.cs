    public static class CacheExtensions
    {
        public static Dictionary<TKey,TValue> GetCacheData<TKey, TValue>(this IMemoryCache cache, TKey key)
        {
            var data = new Dictionary<TKey, TValue>();
            var value = (TValue)(cache.Get(key) ?? default(TValue));
            data.Add(key, value);
            return data;
        }
    }
