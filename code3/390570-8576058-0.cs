    public Task<object> AsyncGetResource(string resourceName)
    {
        object valueFromCache;
        if (_myCache.TryGetValue(resourceName, out valueFromCache)) {
            var tcs = new TaskCompletionSource<object>();
            tcs.SetResult(valueFromCache);
            return tcs.Task;
        }
        return Task.Factory.StartNew<object>(() =>
        {
            // get from disk
            // add to cache
            // return resource
        });
    }
