    public static class CacheExtensions
    {
        public static Dictionary<T1,T2> GetCacheData<T1, T2>(this IMemoryCache cache, object key)
        {
            var data = new Dictionary<T1, T2>();
            var value = (T2)(cache.Get(key) ?? default(T2));
            data.Add((T1)key, value);
            return data;
        }
    }
