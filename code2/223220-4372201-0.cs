    var cacheValue = operation();
    lock (this.Cache)
                {
                    if (!this.Cache.Contains(key))
                    {
                        // Perform the operation to get value for cache here
                        this.Cache.Add(key, cacheValue);
                    }
                }
