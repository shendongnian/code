    public void AddFactory<T>(string key, Func<T> factory)
    {
          // IDictionary<string, Func<T>> factoryCache
          factoryCache.Add(key, factory);
    }
