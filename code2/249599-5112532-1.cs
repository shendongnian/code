      public static class Locking
    {
        private static readonly Dictionary<object, Exception> CorruptionStateDictionary = new Dictionary<object, Exception>();
        private static readonly object CorruptionLock = new object();
        public static bool TryLockedAction(object lockObject, Action action, out Exception exception)
        {
            var lockTaken = false;
            exception = null;
            try
            {
                Monitor.Enter(lockObject, ref lockTaken);
                if (IsCorrupt(lockObject))
                {
                    exception = new LockingException("Cannot execute locked action on a corrupt object.");
                    return false;
                }
                action.Invoke();
            }
            catch (Exception ex)
            {
                var corruptionLockTaken = false;
                exception = ex;
                try
                {
                    Monitor.Enter(CorruptionLock, ref corruptionLockTaken);
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
                    if (corruptionLockTaken)
                    {
                        Monitor.Exit(CorruptionLock);
                    }
                }
            }
            finally
            {
                if (lockTaken)
                {
                    Monitor.Exit(lockObject);
                }
            }
            return exception == null;
        }
        public static void Uncorrupt(object corruptLockObject)
        {
            var lockTaken = false;
            try
            {
                Monitor.Enter(CorruptionLock, ref lockTaken);
                if (IsCorrupt(corruptLockObject))
                {
                    { CorruptionStateDictionary.Remove(corruptLockObject); }
                }
            }
            finally
            {
                if (lockTaken)
                {
                    Monitor.Exit(CorruptionLock);
                }
            }
        }
        public static bool IsCorrupt(object lockObject)
        {
            Exception ex = null;
            return IsCorrupt(lockObject, out ex);
        }
        public static bool IsCorrupt(object lockObject, out Exception ex)
        {
            var lockTaken = false;
            ex = null;
            try
            {
                Monitor.Enter(CorruptionLock, ref lockTaken);
                if (CorruptionStateDictionary.ContainsKey(lockObject))
                {
                    ex = CorruptionStateDictionary[lockObject];
                }
                return CorruptionStateDictionary.ContainsKey(lockObject);
            }
            finally
            {
                if (lockTaken)
                {
                    Monitor.Exit(CorruptionLock);
                }
            }           
        }
    }
