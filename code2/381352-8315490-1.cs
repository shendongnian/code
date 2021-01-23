        public class RememberMaxDictionary<K, V> : IDictionary<K, V> where K: IComparable<K>
        {
            private Dictionary<K, V> _inner;
            public RememberMaxDictionary()
            {
                _inner = new Dictionary<K, V>();
            }
            public K MaxKey { get; private set; }
            public void Add(K key, V value)
            {
                _inner.Add(key, value);
                if (key.CompareTo(MaxKey) > 0) // test null if needed
                {
                    MaxKey = key;
                }
            }
        ... TODO implement the rest...
