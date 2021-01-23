    public class ArbitrarySortedDictionary<TKEY, TSORT, TVALUE> : IDictionary<TKEY, TVALUE>
    {
        readonly Func<TVALUE, TSORT> _SortFunc;
        readonly Dictionary<TKEY, TVALUE> _InternalDict = new Dictionary<TKEY, TVALUE>();
        readonly SortedList<TSORT, TKEY> _SortedKeys = new SortedList<TSORT, TKEY>();
        readonly SortedList<TSORT, TVALUE> _SortedValues = new SortedList<TSORT, TVALUE>();
        public ArbitrarySortedDictionary(Func<TVALUE, TSORT> sortFunc)
        {
            _SortFunc = sortFunc;
        }
        public void Add(TKEY key, TVALUE value)
        {
            if (key == null)
                throw new ArgumentException("Null key is not allowed.");
            var sortKey = _SortFunc(value);
            if (key == null)
                throw new ArgumentException("Null sort value is not allowed.");
            _InternalDict.Add(key, value);
            _SortedKeys.Add(sortKey, key);
            _SortedValues.Add(sortKey, value);
        }
        public bool ContainsKey(TKEY key)
        {
            return _InternalDict.ContainsKey(key);
        }
        public ICollection<TKEY> Keys
        {
            get
            {
                return _SortedKeys.Values.ToList<TKEY>();
            }
        }
        public bool Remove(TKEY key)
        {
            var val = _InternalDict[key];
            if (!_InternalDict.Remove(key))
                return false;
            var sortKey = _SortFunc(val);
            var retVal = _SortedKeys.Remove(sortKey);
            return retVal || _SortedValues.Remove(sortKey);
        }
        public bool TryGetValue(TKEY key, out TVALUE value)
        {
            return _InternalDict.TryGetValue(key, out value);
        }
        public ICollection<TVALUE> Values
        {
            get {
                return _SortedValues.Values.ToList<TVALUE>();
            }
        }
        public TVALUE this[Int32 index]
        {
            get {
                return _InternalDict[_SortedKeys.Values[index]];
            }
            set {
                throw new NotImplementedException("Can't update ArbitrarySortedDictionary directly.");
            }
        }
        public TVALUE this[TKEY key]
        {
            get {
                return _InternalDict[key];
            }
            set {
                if (!ContainsKey(key)) {
                    Add(key, value);
                    return;
                }
                throw new NotImplementedException("To update items currently, remove and re-add.");
            }
        }
        public void Add(KeyValuePair<TKEY, TVALUE> item)
        {
            var sortVal = _SortFunc(item.Value);
            _InternalDict.Add(item.Key, item.Value);
            _SortedKeys.Add(sortVal, item.Key);
            _SortedValues.Add(sortVal, item.Value);
        }
        public void Clear()
        {
            _SortedKeys.Clear();
            _SortedValues.Clear();
            _InternalDict.Clear();
        }
        public bool Contains(KeyValuePair<TKEY, TVALUE> item)
        {
            var val = _InternalDict[item.Key];
            if (val == null)
                return item.Value == null;
            return val.Equals(item.Value);
        }
        public void CopyTo(KeyValuePair<TKEY, TVALUE>[] array, int arrayIndex)
        {
            Int32 curIndex = arrayIndex;
            foreach (var item in this)
                array[curIndex++] = item;
        }
        public int Count
        {
            get { return _InternalDict.Count; }
        }
        public bool IsReadOnly
        {
            get { return false; }
        }
        public bool Remove(KeyValuePair<TKEY, TVALUE> item)
        {
            var val = _InternalDict[item.Key];
            if (!_InternalDict.Remove(item.Key))
                return false;
            var sortKey = _SortFunc(item.Value);
            return _SortedKeys.Remove(_SortFunc(item.Value));
        }
        public IEnumerator<KeyValuePair<TKEY, TVALUE>> GetEnumerator()
        {
            var res =
                from k in _SortedKeys
                join v in _SortedValues on k.Key equals v.Key
                orderby k.Key
                select new KeyValuePair<TKEY, TVALUE>(k.Value, v.Value);
            return res.GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
