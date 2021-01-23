    public Task<object> AsyncGetResource(string resourceName)
    {
        object valueFromCache;
        if (_myCache.TryGetValue(resourceName, out valueFromCache)) {
            return Task.FromResult(valueFromCache);
        }
        return Task.Factory.StartNew<object>(() =>
        {
            // get from disk
            // add to cache
            // return resource
        });
    }
