    public class LockProvider
    {
        private readonly object dictionaryLock = new object();
        private readonly Dictionary<String, Object> locks = 
            new Dictionary<string, object>(StringComparer.Ordinal);
        public ILocker GetLockObjectForKey(string key)
        {
            object keyLock = this.GetKeyLock(key);
            return new Locker(this, key, keyLock);
        }
        private object GetKeyLock(string key)
        {
            object keyLock = null;
            lock (this.dictionaryLock)
            {
                if (!this.locks.TryGetValue(key, out keyLock))
                {
                    this.locks[key] = keyLock = new object();
                }
            }
            return keyLock;
        }
        private sealed class Locker : ILocker
        {
            private readonly LockProvider provider;
            private readonly string key;
            private object keyLock;
            internal Locker(LockProvider provider, string key, 
                object keyLock)
            {
                this.provider = provider;
                this.key = key;
                this.keyLock = keyLock;
            }
            public void Enter()
            {
                Monitor.TryEnter(this.keyLock);
            }
            public void Dispose()
            {
                if (this.keyLock != null)
                {
                    this.Exit();
                    this.keyLock = null;
                }
            }
            private void Exit()
            {
                lock (this.provider.dictionaryLock)
                {
                    try
                    {
                        // Remove the key before releasing the lock.
                        this.provider.locks.Remove(this.key);
                    }
                    finally
                    {
                        // Release the keyLock inside the dictionaryLock.
                        Monitor.Exit(this.keyLock)
                    }
                }            
            }
        }
    }
