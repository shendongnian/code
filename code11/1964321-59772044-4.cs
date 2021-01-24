    private T GetCache<T>()
        where T : BaseCache
    {
        if (typeof(T) == typeof(ConfigCache))
        {
             if (m_ConfigCache == null)
                 m_ConfigCache = new ConfigCache();
            return (T)(object)m_ConfigCache;
        }
        // Support for other types of caches.
    }
