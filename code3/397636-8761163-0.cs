    class OrderedMap<TKey, TValue> {
      private readonly Dictionary<TKey, TValue> _map = new Dictionary<TKey, TValue>();
      private readonly List<TKey> _list = new List<TKey>();
    
      public void Add(TKey key, TValue value) {
        _map[key] = value;
        _list.Add(key);
      }
    
      public void Add(TKey key, TValue value, int index) {
        _map[key] = value;
        _list.Insert(0, key);
      }
     
      public TValue GetValue(TKey key) {
        return _map[key];
      }
    
      public IEnumerabe<KeyValuePair<TKey, TValue>> GetItems() {
        foreach (var key in _list) { 
          var value = _map[key];
          yield return new KeyValuePair<TKey, TValue>(key, value);
        }
      }
    }
