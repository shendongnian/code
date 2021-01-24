    public class CaseDictionary<TValue> : IDictionary<string, TValue>, IDictionary, IReadOnlyDictionary<string, TValue> {
        #region Members
        Dictionary<string, Dictionary<string, TValue>> CIDict;
        #endregion
    
        #region Constructors
        public CaseDictionary() {
            CIDict = new Dictionary<string, Dictionary<string, TValue>>(StringComparer.OrdinalIgnoreCase);
        }
    
        public CaseDictionary(int init) {
            CIDict = new Dictionary<string, Dictionary<string, TValue>>(init, StringComparer.OrdinalIgnoreCase);
        }
    
        public CaseDictionary(IDictionary<string, TValue> init)
            : this(init != null ? init.Count : 0) {
            foreach (var kvp in init)
                Add(kvp.Key, kvp.Value);
        }
        #endregion
    
        #region Properties
        public ICollection<string> Keys => CIDict.Values.SelectMany(v => v.Keys).ToList();
        public ICollection<TValue> Values => CIDict.Values.SelectMany(v => v.Values).ToList();
        public int Count => CIDict.Values.Select(v => v.Count).Sum();
    
        public TValue this[string aKey]
        {
            get
            {
                if (CIDict.TryGetValue(aKey, out var possibles) && possibles.TryGetValue(aKey, out var theValue))
                    return theValue;
                throw new KeyNotFoundException();
            }
            set
            {
                if (CIDict.TryGetValue(aKey, out var possibles)) {
                    if (possibles.ContainsKey(aKey))
                        possibles[aKey] = value;
                    else
                        possibles.Add(aKey, value);
                }
                else
                    CIDict.Add(aKey, new Dictionary<string, TValue>() { { aKey, value } });
            }
        }
        #endregion
    
        #region Methods
        public void Add(string aKey, TValue aValue) {
            if (CIDict.TryGetValue(aKey, out var values))
                values.Add(aKey, aValue);
            else
                CIDict.Add(aKey, new Dictionary<string, TValue>() { { aKey, aValue } });
        }
    
        public bool ContainsKey(string aKey) {
            if (CIDict.TryGetValue(aKey, out var possibles))
                return possibles.ContainsKey(aKey);
            else
                return false;
        }
    
        public bool Remove(string aKey) {
            if (CIDict.TryGetValue(aKey, out var possibles))
                return possibles.Remove(aKey);
            else
                return false;
        }
    
        public bool TryGetValue(string aKey, out TValue theValue) {
            if (CIDict.TryGetValue(aKey, out var possibles))
                return possibles.TryGetValue(aKey, out theValue);
            else {
                theValue = default(TValue);
                return false;
            }
        }
        #endregion
    
        #region ICollection<KeyValuePair<,>> Properties and Methods
        bool ICollection<KeyValuePair<string, TValue>>.IsReadOnly => false;
    
        void ICollection<KeyValuePair<string, TValue>>.Add(KeyValuePair<string, TValue> item) => Add(item.Key, item.Value);
        public void Clear() => CIDict.Clear();
    
        bool ICollection<KeyValuePair<string, TValue>>.Contains(KeyValuePair<string, TValue> item) {
            if (CIDict.TryGetValue(item.Key, out var possibles))
                return ((ICollection<KeyValuePair<string, TValue>>)possibles).Contains(item);
            else
                return false;
        }
    
        bool ICollection<KeyValuePair<string, TValue>>.Remove(KeyValuePair<string, TValue> item) {
            if (CIDict.TryGetValue(item.Key, out var possibles))
                return ((ICollection<KeyValuePair<string, TValue>>)possibles).Remove(item);
            else
                return false;
        }
    
        public void CopyTo(KeyValuePair<string, TValue>[] array, int index) {
            if (array == null)
                throw new ArgumentNullException("array");
            if (index < 0 || index > array.Length)
                throw new ArgumentException("index must be non-negative and within array argument Length");
            if (array.Length - index < Count)
                throw new ArgumentException("array argument plus index offset is too small");
    
            foreach (var subd in CIDict.Values)
                foreach (var kvp in subd)
                    array[index++] = kvp;
        }
        #endregion
    
        #region IDictionary Methods
        bool IDictionary.IsFixedSize => false;
        bool IDictionary.IsReadOnly => false;
        ICollection IDictionary.Keys => (ICollection)Keys;
        ICollection IDictionary.Values => (ICollection)Values;
    
        object IDictionary.this[object key]
        {
            get
            {
                if (key == null)
                    throw new ArgumentNullException("key");
                if (key is string aKey)
                    if (CIDict.TryGetValue(aKey, out var possibles))
                        if (possibles.TryGetValue(aKey, out var theValue))
                            return theValue;
    
                return null;
            }
            set
            {
                if (key == null)
                    throw new ArgumentNullException("key");
                if (value == null && default(TValue) != null)
                    throw new ArgumentNullException("value");
                if (key is string aKey) {
                    if (value is TValue aValue)
                        this[aKey] = aValue;
                    else
                        throw new ArgumentException("value argument has wrong type");
                }
                else
                    throw new ArgumentException("key argument has wrong type");
            }
        }
    
        void IDictionary.Add(object key, object value) {
            if (key == null)
                throw new ArgumentNullException("key");
            if (value == null && default(TValue) != null)
                throw new ArgumentNullException("value");
            if (key is string aKey) {
                if (value is TValue aValue)
                    Add(aKey, aValue);
                else
                    throw new ArgumentException("value argument has wrong type");
            }
            else
                throw new ArgumentException("key argument has wrong type");
        }
    
        bool IDictionary.Contains(object key) {
            if (key == null)
                throw new ArgumentNullException("key");
    
            if (key is string aKey)
                if (CIDict.TryGetValue(aKey, out var possibles))
                    return possibles.ContainsKey(aKey);
    
            return false;
        }
    
        void IDictionary.Remove(object key) {
            if (key == null)
                throw new ArgumentNullException("key");
    
            if (key is string aKey)
                Remove(aKey);
        }
        #endregion
    
        #region ICollection Methods
        bool ICollection.IsSynchronized => false;
        object ICollection.SyncRoot => throw new NotImplementedException();
    
        void ICollection.CopyTo(Array array, int index) {
            if (array == null)
                throw new ArgumentNullException("array");
            if (array.Rank != 1)
                throw new ArgumentException("array argument can not be multi-dimensional");
            if (array.GetLowerBound(0) != 0)
                throw new ArgumentException("array argument has non-zero lower bound");
    
            if (array is KeyValuePair<string, TValue>[] kvps) {
                CopyTo(kvps, index);
            }
            else {
                if (index < 0 || index > array.Length)
                    throw new ArgumentException("index must be non-negative and within array argument Length");
                if (array.Length - index < Count)
                    throw new ArgumentException("array argument plus index offset is too small");
                if (array is DictionaryEntry[] des) {
                    foreach (var subd in CIDict.Values)
                        foreach (var kvp in subd)
                            des[index++] = new DictionaryEntry(kvp.Key, kvp.Value);
                }
                else if (array is object[] objects) {   
                    foreach (var subd in CIDict.Values)
                        foreach (var kvp in subd)
                            objects[index++] = kvp;
                }
                else
                    throw new ArgumentException("array argument is an invalid type");
            }
        }
        #endregion
    
        #region IReadOnlyDictionary<,> Methods
        IEnumerable<string> IReadOnlyDictionary<string, TValue>.Keys => CIDict.Values.SelectMany(v => v.Keys);
        IEnumerable<TValue> IReadOnlyDictionary<string, TValue>.Values => CIDict.Values.SelectMany(v => v.Values);
        #endregion
    
        #region Case-Insensitive Properties and Methods
        public ICollection<string> KeysCI => CIDict.Keys;
        public IndexerPropertyAtCI AtCI => new IndexerPropertyAtCI(this);
    
        public bool ContainsKeyCI(string aKey) => CIDict.ContainsKey(aKey);
        public bool TryGetValueCI(string aKey, out ICollection<TValue> rtnValues) {
            if (CIDict.TryGetValue(aKey, out var theValues)) {
                rtnValues = theValues.Select(v => v.Value).ToList();
                return true;
            }
            else {
                rtnValues = default(List<TValue>);
                return false;
            }
        }
    
        public class IndexerPropertyAtCI {
            CaseDictionary<TValue> myDict;
    
            public IndexerPropertyAtCI(CaseDictionary<TValue> d) => myDict = d;
    
            public ICollection<TValue> this[string aKey] => myDict.CIDict[aKey].Select(v => v.Value).ToList();
        }
        #endregion
    
        #region IEnumerable Methods
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    
        public IEnumerator<KeyValuePair<string, TValue>> GetEnumerator() {
            foreach (var subd in CIDict.Values)
                foreach (var kvp in subd)
                    yield return kvp;
        }
    
        IDictionaryEnumerator IDictionary.GetEnumerator() => new CaseDictionaryEnumerator(GetEnumerator());
    
        struct CaseDictionaryEnumerator : IDictionaryEnumerator {
            private IEnumerator<KeyValuePair<string, TValue>> en;
    
            public CaseDictionaryEnumerator(IEnumerator<KeyValuePair<string, TValue>> anEn) => en = anEn;
    
            public DictionaryEntry Entry => new DictionaryEntry(en.Current.Key, en.Current.Value);
            public object Current => Entry;
    
            public bool MoveNext() => en.MoveNext();
            public void Reset() => en.Reset();
    
            public object Key => en.Current.Key;
            public object Value => en.Current.Value;
        }
        #endregion
    }
