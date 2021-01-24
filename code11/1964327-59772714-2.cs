class CacheFactory<TConfigCache> 
    where TConfigCache: class, BaseCache, new()
{
    public CacheFactory(TConfigCache configCache)
    {
        ConfigCache = configCache;
    }
    private TConfigCache ConfigCache { get; set; }
    public TCache GetCache<TCache>()
        where TCache: class, BaseCache, new()
    {
        if (typeof(TConfigCache) == typeof(TCache))
        {
            if (ConfigCache == null)
            {
                ConfigCache = new TConfigCache();
            }
            return ConfigCache as TCache;
        }
        return new TCache();
    }
}
Be sure to add **class** in the generic requirements.
**EDIT**
Or you can use not generic implementation.
class CacheFactory{
    public CacheFactory(ConfigCache configCache)
    {
        ConfigCache = configCache;
    }
    private ConfigCache ConfigCache { get; set; }
    public TCache GetCache<TCache>()
        where TCache: class, BaseCache, new()
    {
        if (typeof(ConfigCache) == typeof(TCache))
        {
            if (ConfigCache == null)
            {
                ConfigCache = new ConfigCache();
            }
            return ConfigCache as TCache;
        }
        return new TCache();
    }
}
**EDIT 2**
Its full code of my test application and its work.
Maybe it will help.
interface BaseCache { }
class ConfigCache : BaseCache { }
class MyCache : BaseCache { }
class CacheFactory{
    public CacheFactory(ConfigCache configCache)
    {
        ConfigCache = configCache;
    }
    private ConfigCache ConfigCache { get; set; }
    public TCache GetCache<TCache>()
        where TCache: class, BaseCache, new()
    {
        if (typeof(ConfigCache) == typeof(TCache))
        {
            if (ConfigCache == null)
            {
                ConfigCache = new ConfigCache();
            }
            return ConfigCache as TCache;
        }
        return new TCache();
    }
}
class Program
{
    static void Main(string[] args)
    {
        var configCache = new ConfigCache();
        var factory = new CacheFactory(configCache);
        var cache1 = factory.GetCache<ConfigCache>();
        var cache2 = factory.GetCache<MyCache>();
        Print(configCache);
        Print(cache1);
        Print(cache2);
        Console.ReadKey();
    }
    static void Print(BaseCache cache)
    {
        Console.WriteLine("BaseCache: {0}, {1}", cache.GetType().FullName, cache.GetHashCode());
    }
}
