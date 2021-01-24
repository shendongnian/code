    public class ReadOnlyDictionaryUpcast<TKey, TValueDerived, TValueBase>
        : IReadOnlyDictionary<TKey, TValueBase> where TValueDerived : TValueBase
    {
        private Dictionary<TKey, TValueDerived> _dictionary;
        public ReadOnlyDictionaryUpcast(Dictionary<TKey, TValueDerived> dictionary)
        {
            _dictionary = dictionary;
        }
        public int Count => _dictionary.Count;
        public TValueBase this[TKey key] => _dictionary[key];
        public bool ContainsKey(TKey key) => _dictionary.ContainsKey(key);
        public bool TryGetValue(TKey key, out TValueBase value)
        {
            if (_dictionary.TryGetValue(key, out TValueDerived valueDerived))
            {
                value = valueDerived;
                return true;
            }
            value = default;
            return false;
        }
        public IEnumerator<KeyValuePair<TKey, TValueBase>> GetEnumerator()
        {
            foreach (var entry in _dictionary)
            {
                yield return new KeyValuePair<TKey, TValueBase>(entry.Key, entry.Value);
            }
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        public IEnumerable<TKey> Keys => _dictionary.Keys;
        public IEnumerable<TValueBase> Values
        {
            get
            {
                foreach (var value in _dictionary.Values)
                {
                    yield return value;
                }
            }
        }
    }
