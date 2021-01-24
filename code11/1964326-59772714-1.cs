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
