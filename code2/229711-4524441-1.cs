    static class WithLock
    {
        public static T Execute<T>(object o, Func<T> action)
        {
            lock (o)
            {
                return action();
            }
        }
    }
