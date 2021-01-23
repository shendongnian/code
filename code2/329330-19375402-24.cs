    public class StringLocker
    {
        private readonly ConcurrentDictionary<string, string> _locks =
            new ConcurrentDictionary<string, string>();
        public string GetLockObject(string s)
        {
            return _locks.GetOrAdd(s, String.Copy);
        }
    }
