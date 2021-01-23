        public sealed class IntermediateCache<T>
        {
            private Dictionary<string, T> _dictionary = new Dictionary<string, T>();
            
            private IntermediateCache()
            {
            }
            public static IntermediateCache<T> Current
            {
                get
                {
                    string key = "IntermediateCache|" + typeof(T).FullName;
                    IntermediateCache<T> current = HttpContext.Current.Cache[key] as IntermediateCache<T>;
                    if (current == null)
                    {
                        current = new IntermediateCache<T>();
                        HttpContext.Current.Cache[key] = current;
                    }
                    return current;
                }
            }
            public T Get(string key, T defaultValue)
            {
                if (key == null)
                    throw new ArgumentNullException("key");
                T value;
                if (_dictionary.TryGetValue(key, out value))
                    return value;
                return defaultValue;
            }
            public void Set(string key, T value)
            {
                if (key == null)
                    throw new ArgumentNullException("key");
                _dictionary[key] = value;
            }
            public void Clear()
            {
                _dictionary.Clear();
            }
        }
