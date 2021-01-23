    public class LockProvider
    {
        private readonly dictionaryLock = new object();
        private readonly Dictionary<String, Object> locks = 
            new Dictionary<string, object>(StringComparer.Ordinal);
        public object GetLockObjectForKey(string key)
        {
            lock (this.dictionaryLock)
            {
                object keyLock = null;
            
                if (!this.locks.TryGetValue(key, out keyLock))
                {
                    keyLock = new object();
                    this.locks[key] = keyLock;
                }
                
                return keyLock;
            }
        }
    }
