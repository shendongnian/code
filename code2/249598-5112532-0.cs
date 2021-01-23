     public static class Locking
    {
        private static readonly Dictionary<object, Exception> CorruptionStateDictionary = new Dictionary<object, Exception>();
        private static readonly object CorruptionLock = new object();
        public static bool TryLockedAction(object lockObject, Action action, out Exception exception)
        {
            exception = null;
            try
            {
                Monitor.Enter(lockObject);
                if (IsCorrupt(lockObject))
                {
                    exception = new LockingException("Cannot execute locked action on a corrupt object.");
                    return false;
                }
                action.Invoke();
            }
            catch (Exception ex)
            {
                exception = ex;
                try
                {
                    Monitor.Enter(CorruptionLock);
                    if (CorruptionStateDictionary.ContainsKey(lockObject))
                    {
                        CorruptionStateDictionary[lockObject] = ex;
                    }
                    else
                    {
                        CorruptionStateDictionary.Add(lockObject, ex);
                    }
                }
                finally
                {
                    Monitor.Exit(CorruptionLock);
                }
            }
            finally
            {
                Monitor.Exit(lockObject);
            }
            return exception == null;
        }
        public static void Uncorrupt(object corruptLockObject)
        {
            try
            {
                Monitor.Enter(CorruptionLock);
                if (IsCorrupt(corruptLockObject))
                {
                    { CorruptionStateDictionary.Remove(corruptLockObject); }
                }
            }
            finally
            {
                Monitor.Exit(CorruptionLock);
            }
            
        }
        public static bool IsCorrupt(object lockObject)
        {
            Exception ex = null;
            return IsCorrupt(lockObject, out ex);
        }
        public static bool IsCorrupt(object lockObject,out Exception ex)
        {
            ex = null;
            lock (CorruptionLock)
            {
                if (CorruptionStateDictionary.ContainsKey(lockObject))
                {
                    ex = CorruptionStateDictionary[lockObject];
                }
                return CorruptionStateDictionary.ContainsKey(lockObject);
            }
        }
    }
