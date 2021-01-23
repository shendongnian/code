        /// <summary>
        /// This class can be used to override the default functionality of the generic Dictionary class.
        /// </summary>
        /// <typeparam name="TKey">Key type</typeparam>
        /// <typeparam name="TValue">Value type</typeparam>
        public class VirtualDictionary<TKey, TValue> : IDictionary<TKey, TValue>
        {
            protected IDictionary<TKey, TValue> wrappedDictionary;
    
            public VirtualDictionary()
            {
                this.wrappedDictionary = new Dictionary<TKey, TValue>();
            }
    
            public VirtualDictionary(int capacity)
            {
                this.wrappedDictionary = new Dictionary<TKey, TValue>(capacity);
            }
    
            public VirtualDictionary(IEqualityComparer<TKey> comparer)
            {
                this.wrappedDictionary = new Dictionary<TKey, TValue>(comparer);
            }
    
            public VirtualDictionary(int capacity, IEqualityComparer<TKey> comparer)
            {
                this.wrappedDictionary = new Dictionary<TKey, TValue>(capacity, comparer);
            }
    
            public VirtualDictionary(IDictionary<TKey, TValue> dictionary)
            {
                this.wrappedDictionary = new Dictionary<TKey, TValue>(dictionary);
            }
    
            public VirtualDictionary(IDictionary<TKey, TValue> dictionary, IEqualityComparer<TKey> comparer)
            {
                this.wrappedDictionary = new Dictionary<TKey, TValue>(dictionary, comparer);
            }
    
            public virtual void Add(TKey key, TValue value)
            {
                wrappedDictionary.Add(key, value);
            }
    
            public virtual bool ContainsKey(TKey key)
            {
                return wrappedDictionary.ContainsKey(key);
            }
    
            public virtual ICollection<TKey> Keys
            {
                get
                {
                    return wrappedDictionary.Keys;
                }
            }
    
            public virtual bool Remove(TKey key)
            {
                return wrappedDictionary.Remove(key);
            }
    
            public virtual bool TryGetValue(TKey key, out TValue value)
            {
                return wrappedDictionary.TryGetValue(key, out value);
            }
    
            public virtual ICollection<TValue> Values
            {
                get
                {
                    return wrappedDictionary.Values;
                }
            }
    
            public virtual TValue this[TKey key]
            {
                get
                {
                    return wrappedDictionary[key];
                }
                set
                {
                    wrappedDictionary[key] = value;
                }
            }
    
            public virtual void Add(KeyValuePair<TKey, TValue> item)
            {
                wrappedDictionary.Add(item);
            }
    
            public virtual void Clear()
            {
                wrappedDictionary.Clear();
            }
    
            public virtual bool Contains(KeyValuePair<TKey, TValue> item)
            {
                return wrappedDictionary.Contains(item);
            }
    
            public virtual void CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex)
            {
                wrappedDictionary.CopyTo(array, arrayIndex);
            }
    
            public virtual int Count
            {
                get
                {
                    return wrappedDictionary.Count;
                }
            }
    
            public virtual bool IsReadOnly
            {
                get { return wrappedDictionary.IsReadOnly; }
            }
    
            public virtual bool Remove(KeyValuePair<TKey, TValue> item)
            {
                return wrappedDictionary.Remove(item);
            }
    
            protected virtual IEnumerator<KeyValuePair<TKey, TValue>> VirtualGetEnumerator()
            {
                return wrappedDictionary.GetEnumerator();
            }
    
            IEnumerator<KeyValuePair<TKey, TValue>> IEnumerable<KeyValuePair<TKey, TValue>>.GetEnumerator()
            {
                return this.VirtualGetEnumerator();
            }
    
            System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
            {
                return this.VirtualGetEnumerator();
            }
        }
