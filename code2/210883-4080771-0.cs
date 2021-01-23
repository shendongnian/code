    public class ListedDictionary<TKey, TValue> : IDictionary<TKey, TValue>
    {
        List<TValue> _list = new List<TValue>();
        Dictionary<TKey, TValue> _dictionary = new Dictionary<TKey,TValue>();
    
        public IEnumerable<TValue> ListedValues
        {
            get { return _list; }
        }
    
        public void Add(TKey key, TValue value)
        {
            _dictionary.Add(key, value);
            _list.Add(value);
        }
    
        public bool ContainsKey(TKey key)
        {
            return _dictionary.ContainsKey(key);
        }
    
        public ICollection<TKey> Keys { get { return _dictionary.Keys; } }
    
        public bool Remove(TKey key)
        {
            _list.Remove(_dictionary[key]);
            return _dictionary.Remove(key);
        }
     
        // further interface methods...
    }
