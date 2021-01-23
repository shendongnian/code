    public class NamespaceDictionary<T> : IDictionary<string, T>
    {
        private SortedDictionary<string, Dictionary<string, T>> _dict;
        private const char _separator = '.';
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
            int pos = name.LastIndexOf(_separator);
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
        public bool ContainsKey(string name)
        {
            var tuple = Split(name);
            return ContainsKey(tuple.Item1, tuple.Item2);
        }
        public bool ContainsKey(string ns, string key)
        {
            if (ns == "")
                return _dict.Any(pair => pair.Value.ContainsKey(key));
            return _dict.ContainsKey(ns) && _dict[ns].ContainsKey(key);
        }
        public void Add(string name, T value)
        {
            var tuple = Split(name);
            Add(tuple.Item1, tuple.Item2, value);
        }
        public void Add(string ns, string key, T value)
        {
            if (!_dict.ContainsKey(ns))
                _dict[ns] = new Dictionary<string, T>();
            _dict[ns].Add(key, value);
        }
        public bool Remove(string ns, string key)
        {
            if (_dict.ContainsKey(ns) && _dict[ns].ContainsKey(key))
            {
                if (_dict[ns].Count == 1) _dict.Remove(ns);
                else _dict[ns].Remove(key);
                return true;
            }
            return false;
        }
        public bool Remove(string key)
        {
            var tuple = Split(key);
            return Remove(tuple.Item1, tuple.Item2);
        }
        public bool TryGetValue(string name, out T value)
        {
            var tuple = Split(name);
            return TryGetValue(tuple.Item1, tuple.Item2, out value);
        }
        public bool TryGetValue(string ns, string key, out T value)
        {
            if (ns == "")
            {
                foreach (var pair in _dict)
                {
                    if (pair.Value.ContainsKey(key))
                    {
                        value = pair.Value[key];
                        return true;
                    }
                }
            }
            else if (_dict.ContainsKey(ns) && _dict[ns].ContainsKey(key))
            {
                value = _dict[ns][key];
                return true;
            }
            value = default(T);
            return false;
        }
        public T this[string ns, string key]
        {
            get
            {
                if (ns == "")
                {
                    foreach (var pair in _dict)
                        if (pair.Value.ContainsKey(key))
                            return pair.Value[key];
                }
                else if (_dict.ContainsKey(ns) && _dict[ns].ContainsKey(key))
                    return _dict[ns][key];
                throw new KeyNotFoundException();
            }
            set
            {
                if (!_dict.ContainsKey(ns))
                    _dict[ns] = new Dictionary<string, T>();
                _dict[ns][key] = value;
            }
        }
        public T this[string name]
        {
            get
            {
                var tuple = Split(name);
                return this[tuple.Item1, tuple.Item2];
            }
            set
            {
                var tuple = Split(name);
                this[tuple.Item1, tuple.Item2] = value;
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
