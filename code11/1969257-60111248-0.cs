            var expirationTime = DateTime.Now.AddMinutes(30);
            var expirationToken = new CancellationChangeToken(
                new CancellationTokenSource(TimeSpan.FromMinutes(31)).Token);
            var cacheEntryOptions = new MemoryCacheEntryOptions()
             .SetPriority(CacheItemPriority.NeverRemove)
             .SetAbsoluteExpiration(expirationTime)
             .AddExpirationToken(expirationToken)
             .RegisterPostEvictionCallback(callback: EvictionCallback, state: this);
            _memoryCache.Set(fakeTransactionId, transaction.Id, cacheEntryOptions);
