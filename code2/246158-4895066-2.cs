    [Serializable]
    public class Foo : IDictionary<string,string>
    {
        private readonly Dictionary<string, string> inner = new Dictionary<string, string>();
        public void Add(string key, string value)
        {
            inner.Add(key, value);
        }
        public bool ContainsKey(string key)
        {
            return inner.ContainsKey(key);
        }
        public ICollection<string> Keys
        {
            get { return inner.Keys; }
        }
        public bool Remove(string key)
        {
            return inner.Remove(key);
        }
        public bool TryGetValue(string key, out string value)
        {
            return inner.TryGetValue(key, out value);
        }
        public ICollection<string> Values
        {
            get { return inner.Values; }
        }
        public string this[string key]
        {
            get
            {
                return inner[key];
            }
            set
            {
                inner[key] = value;
            }
        }
        void  ICollection<KeyValuePair<string, string>>.Add(KeyValuePair<string, string> item)
        {
            ((IDictionary<string,string>)inner).Add(item);
        }
        public void Clear()
        {
            inner.Clear();
        }
        bool ICollection<KeyValuePair<string, string>>.Contains(KeyValuePair<string, string> item)
        {
            return ((IDictionary<string, string>)inner).Contains(item);
        }
        void  ICollection<KeyValuePair<string, string>>.CopyTo(KeyValuePair<string, string>[] array, int arrayIndex)
        {
            ((IDictionary<string, string>)inner).CopyTo(array, arrayIndex);
        }
        public int Count
        {
            get { return inner.Count; }
        }
        bool  ICollection<KeyValuePair<string, string>>.IsReadOnly
        {
            get { return ((IDictionary<string, string>)inner).IsReadOnly; }
        }
        bool ICollection<KeyValuePair<string, string>>.Remove(KeyValuePair<string, string> item)
        {
            return ((IDictionary<string, string>)inner).Remove(item);
        }
        public IEnumerator<KeyValuePair<string, string>> GetEnumerator()
        {
            return inner.GetEnumerator();
        }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return inner.GetEnumerator();
        }
    }
