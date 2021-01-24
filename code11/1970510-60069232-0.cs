    Task<T> GetOrAddAsync<T>(string key, Func<Task<T>> factory,
        int durationMilliseconds = Timeout.Infinite, string customerId = null)
    {
        return GetMemoryCacheProvider().GetOrCreateAsync<T>(key, (options) =>
        {
            if (durationMilliseconds != Timeout.Infinite)
            {
                options.SetSlidingExpiration(TimeSpan.FromMilliseconds(durationMilliseconds));
            }
            if (customerId != null)
            {
                options.ExpirationTokens.Add(GetCustomerExpirationToken(customerId));
            }
            return factory();
        });
    }
