    public class NamespaceDictionary<T> : IDictionary<string, T>
    {
        SortedDictionary<string, Dictionary<string, T>> _dict;
        public NamespaceDictionary()
        {
            _dict = new SortedDictionary<string, Dictionary<string, T>>();
        }
        public NamespaceDictionary(IEnumerable<KeyValuePair<string, T>> collection) 
            : this()
        {
            foreach (var item in collection)
                Add(item);
        }
        #region Implementation of IEnumerable
        public IEnumerator<KeyValuePair<string, T>> GetEnumerator()
        {
            return _dict.SelectMany(x => x.Value).GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        #endregion
        private static Tuple<string, string> Split(string name)
        {
            int pos = name.LastIndexOf('.');
            string ns = pos == -1 ? "" : name.Substring(0, pos);
            string var = name.Substring(pos + 1);
            return new Tuple<string, string>(ns, var);
        }
        #region Implementation of ICollection<KeyValuePair<string,TValue>>
        public void Add(KeyValuePair<string, T> item)
        {
            Add(item.Key, item.Value);
        }
        public void Clear()
        {
            _dict.Clear();
        }
        public bool Contains(KeyValuePair<string, T> item)
        {
            throw new NotImplementedException();
        }
        public void CopyTo(KeyValuePair<string, T>[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }
        public bool Remove(KeyValuePair<string, T> item)
        {
            return Remove(item.Key);
        }
        public int Count
        {
            get { return _dict.Sum(p => p.Value.Count); }
        }
        public bool IsReadOnly
        {
            get { return false; }
        }
        #endregion
        #region Implementation of IDictionary<string,TValue>
        public bool ContainsKey(string key)
        {
            var tuple = Split(key);
            if (tuple.Item1 == "")
                return _dict.Any(pair => pair.Value.ContainsKey(tuple.Item2));
            return _dict.ContainsKey(tuple.Item1) && _dict[tuple.Item1].ContainsKey(tuple.Item2);
        }
        public void Add(string key, T value)
        {
            var tuple = Split(key);
            if (!_dict.ContainsKey(tuple.Item1))
                _dict[tuple.Item1] = new Dictionary<string, T>();
            _dict[tuple.Item1].Add(tuple.Item2, value);
        }
        public bool Remove(string key)
        {
            var tuple = Split(key);
            if (_dict.ContainsKey(tuple.Item1) && _dict[tuple.Item1].ContainsKey(tuple.Item2))
            {
                if (_dict[tuple.Item1].Count == 1) _dict.Remove(tuple.Item1);
                else _dict[tuple.Item1].Remove(tuple.Item2);
                return true;
            }
            return false;
        }
        public bool TryGetValue(string key, out T value)
        {
            var tuple = Split(key);
            if (tuple.Item1 == "")
            {
                foreach (var pair in _dict)
                {
                    if (pair.Value.ContainsKey(tuple.Item2))
                    {
                        value = pair.Value[tuple.Item2];
                        return true;
                    }
                }
            }
            else if (_dict.ContainsKey(tuple.Item1) && _dict[tuple.Item1].ContainsKey(tuple.Item2))
            {
                value = _dict[tuple.Item1][tuple.Item2];
                return true;
            }
            value = default(T);
            return false;
        }
        public T this[string key]
        {
            get
            {
                var tuple = Split(key);
                if (tuple.Item1 == "")
                {
                    foreach (var pair in _dict)
                        if (pair.Value.ContainsKey(tuple.Item2))
                            return pair.Value[tuple.Item2];
                }
                else if (_dict.ContainsKey(tuple.Item1) && _dict[tuple.Item1].ContainsKey(tuple.Item2))
                    return _dict[tuple.Item1][tuple.Item2];
                throw new KeyNotFoundException();
            }
            set {
                var tuple = Split(key);
                if (!_dict.ContainsKey(tuple.Item1))
                    _dict[tuple.Item1] = new Dictionary<string, T>();
                _dict[tuple.Item1][tuple.Item2] = value;
            }
        }
        public ICollection<string> Keys
        {
            get { return _dict.SelectMany(p => p.Value.Keys).ToArray(); }
        }
        public ICollection<T> Values
        {
            get { return _dict.SelectMany(p => p.Value.Values).ToArray(); }
        }
        #endregion
    }
