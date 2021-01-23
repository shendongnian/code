    /// <summary>
    /// Provides a mechanism to lock based on a data item being retrieved
    /// </summary>
    /// <typeparam name="T">Type of the data being used as a key</typeparam>
    public class LockProvider<T> 
    {
        private object _syncRoot = new object();
        private Dictionary<T, object> _lstLocks = new Dictionary<T, object>();
        /// <summary>
        /// Gets an object suitable for locking the specified data item
        /// </summary>
        /// <param name="key">The data key</param>
        /// <returns></returns>
        public object GetLock(T key)
        {
            if (!_lstLocks.ContainsKey(key))
            {
                lock (_syncRoot)
                {
                    if (!_lstLocks.ContainsKey(key))
                        _lstLocks.Add(key, new object());
                }
            }
            return _lstLocks[key];
        }
    }
