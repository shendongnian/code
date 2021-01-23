    public class KeyValueCollection<TKey, TValue> : Collection<KeyValuePair<TKey, TValue>>
    {
        private Dictionary<TKey, TValue> m_Dictionary = new Dictionary<TKey, TValue>();
    
        public TValue GetValue(TKey key)
        {
            return m_Dictionary[key];
        }
        
        public void Add(TKey key, TValue value)
        {
            m_Dictionary.Add(key, value);
            base.Add(new KeyValuePair<TKey, TValue>(key, value));
        }
    
        protected override void ClearItems()
        {
            m_Dictionary.Clear();
            base.ClearItems();
        }
    
        protected override void InsertItem(int index, KeyValuePair<TKey, TValue> item)
        {
            m_Dictionary.Add(item.Key, item.Value);
            base.InsertItem(index, item);
        }
    
        protected override void RemoveItem(int index)
        {
    
            m_Dictionary.Remove(this[index].Key);
            base.RemoveItem(index);
        }
    
        protected override void SetItem(int index, KeyValuePair<TKey, TValue> item)
        {
            m_Dictionary[this[index].Key] = item.Value;
            base.SetItem(index, item);
        }
    }
