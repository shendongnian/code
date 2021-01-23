    public class Foo
    {
        private static readonly ConcurrentDictionary<string, object> _locks = new ConcurrentDictionary<string, object>();
    
        public void LockOperation(string s)
        {
            lock(_locks.GetOrAdd(s, new object()))
            {
                ...
            }
        }
    }
