    class DistributedHashTable
    {
        public Task SetAsync(string key, string value);
        public Task<string> GetAsync(string key);
    }
