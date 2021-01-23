    void get(string key)
    {
        return HttpRuntime.Cache[key];
    }
    void set(string key, object value, DateTime expires)
    {
        HttpRuntime.Cache.Insert(
            key, 
            value, 
            null, 
            expires, 
            Cache.NoSlidingExpiration);
    }
