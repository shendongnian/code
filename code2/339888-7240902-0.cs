    public class StringToMethodMapper<T, TResult>
    {
        private Dictionary<string, Func<T, TResult>> _methods;
    
        public StringToMethodMapper()
        {
            _methods = new Dictionary<string, Func<T, TResult>>();
        }
    
        public void Add(string key, Func<T, TResult> method)
        {
            _methods.Add(key, method);
        }
    
        internal virtual Func<T, TResult> GetMethodFor(string key)
        {
            foreach (var storedKey in _methods.Keys)
            {
                if (key.ToUpper().StartsWith(storedKey.ToUpper()))
                {
                    return _methods[storedKey];
                }
            }
            return null;
        }
    }
