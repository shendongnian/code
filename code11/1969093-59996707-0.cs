    public interface IMyDistributedCache
    {
    }
    public static class MyDistributedCacheExtensions
    {
        public static void Set(this IMyDistributedCache cache, string key, byte[] value)
        {
        }
    }
    public static class MySecondDistributedCacheExtensions
    {
        public static void Set<T>(this IMyDistributedCache cache, string key, T value) where T : class
        {
            byte[] byteArray = value.ToByteArray();
            cache.Set<byte[]>(key, byteArray); //<<< endless loop
        }
    }
