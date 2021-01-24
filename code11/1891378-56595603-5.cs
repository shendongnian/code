    public class ReadOnlyDictionaryUpcast<TKey, TValueDerived, TValueBase>
        : IReadOnlyDictionary<TKey, TValueBase> where TValueDerived : TValueBase
    {
        private readonly Dictionary<TKey, TValueDerived> _dictionary;
        public ReadOnlyDictionaryUpcast(Dictionary<TKey, TValueDerived> dictionary)
        {
            _dictionary = dictionary;
        }
        public int Count => _dictionary.Count;
        public TValueBase this[TKey key] => _dictionary[key];
        public bool ContainsKey(TKey key) => _dictionary.ContainsKey(key);
        public bool TryGetValue(TKey key, out TValueBase value)
        {
            bool result = _dictionary.TryGetValue(key, out TValueDerived valueDerived);
            value = valueDerived;
            return result;
        }
        public IEnumerator<KeyValuePair<TKey, TValueBase>> GetEnumerator() => _dictionary
            .Select(e => new KeyValuePair<TKey, TValueBase>(e.Key, e.Value))
            .GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        public IEnumerable<TKey> Keys => _dictionary.Keys;
        public IEnumerable<TValueBase> Values => 
            (IEnumerable<TValueBase>)(IEnumerable<TValueDerived>)_dictionary.Values;
    }
