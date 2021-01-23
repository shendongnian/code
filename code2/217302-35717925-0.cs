    public class KeyLocker<TKey>
    {
        private class KeyLock
        {
            public int Count;
        }
    
    	private readonly Dictionary<TKey, KeyLock> keyLocks = new Dictionary<TKey, KeyLock>();
    
    	public T ExecuteSynchronized<T>(TKey key, Func<TKey, T> function)
    	{
            KeyLock keyLock =  null;
            try
            {              
                lock (keyLocks)
                {
                    if (!keyLocks.TryGetValue(key, out keyLock))
                    {
                        keyLock = new KeyLock();
                        keyLocks.Add(key, keyLock);
                    }
                    keyLock.Count++;
                }
                lock (keyLock)
                {
                    return function(key);
                }
            }
            finally
            {         
                lock (keyLocks)
                {
                    if (keyLock != null && --keyLock.Count == 0) keyLocks.Remove(key);
                }
            }
    	}
    
    	public void ExecuteSynchronized(TKey key, Action<TKey> action)
    	{
    		this.ExecuteSynchronized<bool>(key, k =>
    		{
    			action(k);
    			return true;
    		});
    	}
    }
