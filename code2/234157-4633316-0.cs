    class NullableDict<K, V> : IDictionary<K, V>
    {
        Dictionary<K, V> dict = new Dictionary<K, V>();
        V nullValue = default(V);
        bool hasNull = false;
        public NullableDict()
        {
        }
        public void Add(K key, V value)
        {
            if (key == null)
                if (hasNull)
                    throw new ArgumentException("Duplicate key");
                else
                {
                    nullValue = value;
                    hasNull = true;
                }
            else
                dict.Add(key, value);
        }
        public bool ContainsKey(K key)
        {
            if (key == null)
                return hasNull;
            return dict.ContainsKey(key);
        }
        public ICollection<K> Keys
        {
            get 
            {
                if (!hasNull)
                    return dict.Keys;
                List<K> keys = dict.Keys.ToList();
                keys.Add(default(K));
                return new ReadOnlyCollection<K>(keys);
            }
        }
        public bool Remove(K key)
        {
            if (key != null)
                return dict.Remove(key);
            bool oldHasNull = hasNull;
            hasNull = false;
            return oldHasNull;
        }
        public bool TryGetValue(K key, out V value)
        {
            if (key != null)
                return dict.TryGetValue(key, out value);
            value = hasNull ? nullValue : default(V);
            return hasNull;
        }
        public ICollection<V> Values
        {
            get
            {
                if (!hasNull)
                    return dict.Values;
                List<V> values = dict.Values.ToList();
                values.Add(nullValue);
                return new ReadOnlyCollection<V>(values);
            }
        }
        public V this[K key]
        {
            get
            {
                if (key == null)
                    if (hasNull)
                        return nullValue;
                    else
                        throw new KeyNotFoundException();
                else
                    return dict[key];
            }
            set
            {
                if (key == null)
                {
                    nullValue = value;
                    hasNull = true;
                }
                else
                    dict[key] = value;
            }
        }
        public void Add(KeyValuePair<K, V> item)
        {
            Add(item.Key, item.Value);
        }
        public void Clear()
        {
            hasNull = false;
            dict.Clear();
        }
        public bool Contains(KeyValuePair<K, V> item)
        {
            if (item.Key != null)
                return ((ICollection<KeyValuePair<K, V>>)dict).Contains(item);
            if (hasNull)
                return EqualityComparer<V>.Default.Equals(nullValue, item.Value);
            return false;
        }
        public void CopyTo(KeyValuePair<K, V>[] array, int arrayIndex)
        {
            ((ICollection<KeyValuePair<K, V>>)dict).CopyTo(array, arrayIndex);
            if (hasNull)
                array[arrayIndex + dict.Count] = new KeyValuePair<K, V>(default(K), nullValue);
        }
        public int Count
        {
            get { return dict.Count + (hasNull ? 1 : 0); }
        }
        public bool IsReadOnly
        {
            get { return false; }
        }
        public bool Remove(KeyValuePair<K, V> item)
        {
            V value;
            if (TryGetValue(item.Key, out value) && EqualityComparer<V>.Default.Equals(item.Value, value))
                return Remove(item.Key);
            return false;
        }
        public IEnumerator<KeyValuePair<K, V>> GetEnumerator()
        {
            if (!hasNull)
                return dict.GetEnumerator();
            else
                return GetEnumeratorWithNull();
        }
        private IEnumerator<KeyValuePair<K, V>> GetEnumeratorWithNull()
        {
            yield return new KeyValuePair<K, V>(default(K), nullValue);
            foreach (var kv in dict)
                yield return kv;
        }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
