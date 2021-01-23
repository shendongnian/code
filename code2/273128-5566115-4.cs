    public interface ILocker : IDisposable
    {
        void Enter();
        
        void Dispose();
    }
    public class LockProvider
    {
        private readonly object dictionaryLock = new object();
        private readonly Dictionary<String, Object> locks = 
            new Dictionary<string, object>(StringComparer.Ordinal);
        public ILocker GetLockObjectForKey(string key)
        {
            object keyLock = this.GetKeyLock(key);
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
        
        private void RemoveKey(string key, Action callback)
        {
            lock (this.dictionaryLock)
            {
                try
                {
                    this.locks.Remove(key);
                }
                finally
                {
                    // Execute the callback inside the lock.
                    callback();
                }
            }    
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
                this.Exit();
            }
            
            private void Exit()
            {
                if (this.keyLock != null)
                {
                    // Remove the key before releasing the lock.
                    this.provider.RemoveKey(this.key, () =>
                    {
                        // This code is executed within the lock
                        // of the LockProvider.
                        Monitor.Exit(this.keyLock)
                        this.keyLock = null;
                    });
                }        
            }
        }
    }
