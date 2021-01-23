    public static class StringLocker
    {
        private static readonly ConcurrentDictionary<string, object> _locks = new ConcurrentDictionary<string, object>();
    
        public static void DoAction(string s, Action action)
        {
            lock(_locks.GetOrAdd(s, new object()))
            {
                action();
            }
        }
    }
