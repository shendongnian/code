    public static class Locking
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [DebuggerNonUserCode, DebuggerStepThrough]
        public static T WithLock<T>(this object threadSync, Func<T> selector)
        {
            lock (threadSync)
            {
                return selector();
            }
        }
    }
