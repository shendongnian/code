      public class MySpecialDictionary : IDictionary<string, string>
      {
        private IDictionary<string, string> dict = new Dictionary<string, string>();
    
        public int TotalSize { get; private set; }
    
        #region IDictionary<string,string> Members
    
        public void Add(string key, string value)
        {
          dict.Add(key, value);
          TotalSize += string.IsNullOrEmpty(value) ? 0 : value.Length;
        }
    
        public bool ContainsKey(string key)
        {
          return dict.ContainsKey(key);
        }
    
        public ICollection<string> Keys
        {
          get { return dict.Keys; }
        }
    
        public bool Remove(string key)
        {
          string value;
          if (dict.TryGetValue(key, out value))
          {
            TotalSize -= string.IsNullOrEmpty(value) ? 0 : value.Length;
          }
          return dict.Remove(key);
        }
    
        public bool TryGetValue(string key, out string value)
        {
          return dict.TryGetValue(key, out value);
        }
    
        public ICollection<string> Values
        {
          get { return dict.Values; }
        }
    
        public string this[string key]
        {
          get
          {
            return dict[key];
          }
          set
          {
            string v;
            if (dict.TryGetValue(key, out v))
            {
              TotalSize -= string.IsNullOrEmpty(v) ? 0 : v.Length;
            }
            dict[key] = value;
            TotalSize += string.IsNullOrEmpty(value) ? 0 : value.Length;
          }
        }
    
        #endregion
    
        #region ICollection<KeyValuePair<string,string>> Members
    
        public void Add(KeyValuePair<string, string> item)
        {
          dict.Add(item);
          TotalSize += string.IsNullOrEmpty(item.Value) ? 0 : item.Value.Length;
        }
    
        public void Clear()
        {
          dict.Clear();
          TotalSize = 0;
        }
    
        public bool Contains(KeyValuePair<string, string> item)
        {
          return dict.Contains(item);
        }
    
        public void CopyTo(KeyValuePair<string, string>[] array, int arrayIndex)
        {
          dict.CopyTo(array, arrayIndex);
        }
    
        public int Count
        {
          get { return dict.Count; }
        }
    
        public bool IsReadOnly
        {
          get { return dict.IsReadOnly; }
        }
    
        public bool Remove(KeyValuePair<string, string> item)
        {
          string v;
          if (dict.TryGetValue(item.Key, out v))
          {
            TotalSize -= string.IsNullOrEmpty(v) ? 0 : v.Length;
          }
          return dict.Remove(item);
        }
    
        #endregion
    
        #region IEnumerable<KeyValuePair<string,string>> Members
    
        public IEnumerator<KeyValuePair<string, string>> GetEnumerator()
        {
          return dict.GetEnumerator();
        }
    
        #endregion
    
        #region IEnumerable Members
    
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
          return dict.GetEnumerator();
        }
    
        #endregion
      }
