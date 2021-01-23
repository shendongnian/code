    public class ArbitrarySortedDictionary<TKEY, TSORT, TVALUE> : IDictionary<TKEY, TVALUE> 
        where TSORT : IComparable
        where TKEY : IComparable
    {
        /// <summary>
        /// Key class for use in keeping the _SortedKeys and _SortedValues in proper order.  Since the sorting 
        /// function could easily result in same values across instances, we'll use the key as secondary sort
        /// field - since it's unique, everything should always have a consistent, unambiguous sort order.
        /// </summary>
        class SortedDictionaryKey
        {
            public SortedDictionaryKey(TSORT sortVal, TKEY key)
            {
                SortVal = sortVal;
                Key = key;
            }
            public TSORT SortVal
            {
                get;
                private set;
            }
            public TKEY Key
            {
                get;
                private set;
            }
        }
        readonly Func<TVALUE, TSORT> _SortFunc;
        readonly Dictionary<TKEY, TVALUE> _InternalDict = new Dictionary<TKEY, TVALUE>();
        readonly SortedList<SortedDictionaryKey, TKEY> _SortedKeys;
        readonly SortedList<SortedDictionaryKey, TVALUE> _SortedValues;
        public ArbitrarySortedDictionary(Func<TVALUE, TSORT> sortFunc)
        {
            _SortFunc = sortFunc;
            Func<SortedDictionaryKey, SortedDictionaryKey, Int32> compFunc = (x, y) => {
                Int32 sortValComp = 0;
                if (x.SortVal != null)
                    sortValComp = x.SortVal.CompareTo(y.SortVal);
                if (sortValComp != 0)
                    return sortValComp;
                if (x.Key != null)
                    return x.Key.CompareTo(y.Key);
                return y.Key == null ? 0 : -1;
            };
            var comparer = new LambdaComparer<SortedDictionaryKey>(compFunc);
            _SortedKeys = new SortedList<SortedDictionaryKey, TKEY>(comparer);
            _SortedValues = new SortedList<SortedDictionaryKey, TVALUE>(comparer);
        }
        public void Add(TKEY key, TVALUE value)
        {
            if (key == null)
                throw new ArgumentException("Null key is not allowed.");
            var sortKey = new SortedDictionaryKey(_SortFunc(value), key);
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
            get {
                return _SortedKeys.Values.ToList<TKEY>();
            }
        }
        public bool Remove(TKEY key)
        {
            return RemoveInternal(key, _InternalDict[key]);
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
            var sortKey = new SortedDictionaryKey(_SortFunc(item.Value), item.Key);
            _InternalDict.Add(item.Key, item.Value);
            _SortedKeys.Add(sortKey, item.Key);
            _SortedValues.Add(sortKey, item.Value);
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
            return RemoveInternal(item.Key, item.Value);
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
        private Boolean RemoveInternal(TKEY key, TVALUE val)
        {
            if (!_InternalDict.Remove(key))
                return false;
            var sortKey = new SortedDictionaryKey(_SortFunc(val), key);
            var retVal = _SortedKeys.Remove(sortKey);
            return retVal || _SortedValues.Remove(sortKey);
        }
    }
    /// <summary>
    /// Utility class - an IComparer based upon a lambda expression.
    /// </summary>
    public class LambdaComparer<T> : IComparer<T>
    {
        private readonly Func<T, int> _lambdaHash;
        private readonly Func<T, T, int> _lambdaComparer;
        public LambdaComparer(Func<T, T, int> lambdaComparer) :
            this(lambdaComparer, o => 0)
        {
        }
        public LambdaComparer(Func<T, T, int> lambdaComparer, Func<T, int> lambdaHash)
        {
            if (lambdaComparer == null)
                throw new ArgumentNullException("lambdaComparer");
            if (lambdaHash == null)
                throw new ArgumentNullException("lambdaHash");
            _lambdaHash = lambdaHash;
            _lambdaComparer = lambdaComparer;
        }
        public int Compare(T x, T y)
        {
            return _lambdaComparer(x, y);
        }
        public int GetHashCode(T obj)
        {
            return _lambdaHash(obj);
        }
    }
