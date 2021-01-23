    public class WrappedDictionary<K, T> : IDictionary<K, T>
    {
        public IDictionary<K, T> WrappedInstance { get; set; }
        public virtual T this[K key]
        {
            get
            {
                // CUSTOM RESOLUTION CODE GOES HERE
                return this.WrappedInstance[key];
            }
            set
            {
                this.WrappedInstance[key] = value;
            }
        }
        public int Count
        {
            get
            {
                return this.WrappedInstance.Count;
            }
        }
        public bool IsReadOnly
        {
            get
            {
                return this.WrappedInstance.IsReadOnly;
            }
        }
        public ICollection<K> Keys
        {
            get
            {
                return this.WrappedInstance.Keys;
            }
        }
        public ICollection<T> Values
        {
            get
            {
                return this.WrappedInstance.Values;
            }
        }
        public void Add(KeyValuePair<K, T> item)
        {
            this.WrappedInstance.Add(item);
        }
        public void Add(K key, T value)
        {
            this.WrappedInstance.Add(key, value);
        }
        public void Clear()
        {
            this.WrappedInstance.Clear();
        }
        public bool Contains(KeyValuePair<K, T> item)
        {
            return this.WrappedInstance.Contains(item);
        }
        public bool ContainsKey(K key)
        {
            return this.WrappedInstance.ContainsKey(key);
        }
        public void CopyTo(KeyValuePair<K, T>[] array, int arrayIndex)
        {
            this.WrappedInstance.CopyTo(array, arrayIndex);
        }
        public IEnumerator<KeyValuePair<K, T>> GetEnumerator()
        {
            return this.WrappedInstance.GetEnumerator();
        }
        public bool Remove(KeyValuePair<K, T> item)
        {
            return this.WrappedInstance.Remove(item);
        }
        public bool Remove(K key)
        {
            return this.WrappedInstance.Remove(key);
        }
        public bool TryGetValue(K key, out T value)
        {
            // CUSTOM RESOLUTION CODE GOES HERE
            return this.WrappedInstance.TryGetValue(key, out value);
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.WrappedInstance.GetEnumerator();
        }
    }
