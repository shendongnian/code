    public class ReadOnlyDictionary<TKey, TValue> : IDictionary<TKey, TValue>
    {
        private readonly IDictionary<TKey, TValue> sourceDictionary;
        public ICollection<TKey> Keys
        {
            get { return sourceDictionary.Keys; }
        }
        public ICollection<TValue> Values
        {
            get { return sourceDictionary.Values; }
        }
        public TValue this[TKey key]
        {
            get { return sourceDictionary[key]; }
            set { throw new NotSupportedException(); }
        }
        public int Count
        {
            get { return sourceDictionary.Count; }
        }
        public bool IsReadOnly
        {
            get { return true; }
        }
        public ReadOnlyDictionary(IDictionary<TKey, TValue> sourceDictionary)
        {
            AssertUtilities.ArgumentNotNull(sourceDictionary, "sourceDictionary");
            this.sourceDictionary = sourceDictionary;
        }
        void IDictionary<TKey, TValue>.Add(TKey key, TValue value)
        {
            throw new NotSupportedException();
        }
        public bool ContainsKey(TKey key)
        {
            return sourceDictionary.ContainsKey(key);
        }
        bool IDictionary<TKey, TValue>.Remove(TKey key)
        {
            throw new NotSupportedException();
        }
        public bool TryGetValue(TKey key, out TValue value)
        {
            return sourceDictionary.TryGetValue(key, out value);
        }
        void ICollection<KeyValuePair<TKey, TValue>>.Add(KeyValuePair<TKey, TValue> item)
        {
            throw new NotSupportedException();
        }
        void ICollection<KeyValuePair<TKey, TValue>>.Clear()
        {
            throw new NotSupportedException();
        }
        public bool Contains(KeyValuePair<TKey, TValue> item)
        {
            return sourceDictionary.Contains(item);
        }
        public void CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex)
        {
            sourceDictionary.CopyTo(array, arrayIndex);
        }
        bool ICollection<KeyValuePair<TKey, TValue>>.Remove(KeyValuePair<TKey, TValue> item)
        {
            throw new NotSupportedException();
        }
        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
        {
            return sourceDictionary.GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)sourceDictionary).GetEnumerator();
        }
    }
