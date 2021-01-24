    public class CaseDictionary<TValue> : Dictionary<string, Dictionary<string, TValue>> {
        public CaseDictionary()
            : base(StringComparer.OrdinalIgnoreCase) {
        }
    
        public CaseDictionary(int init)
            : base(init, StringComparer.OrdinalIgnoreCase) {
        }
    
        public CaseDictionary(IDictionary<string, TValue> init)
            : this(init != null ? init.Count : 0) {
            foreach (var kvp in init)
                Add(kvp.Key, kvp.Value);
        }
    
        public void Add(string aKey, TValue aValue) {
            if (TryGetValue(aKey, out var values))
                values.Add(aKey, aValue);
            else
                Add(aKey, new Dictionary<string, TValue>() { { aKey, aValue } });
        }
    
        public bool ContainsKeyCS(string aKey) {
            if (TryGetValue(aKey, out var possibles))
                return possibles.ContainsKey(aKey);
            else
                return false;
        }
    
        public bool TryGetValueCS(string aKey, out TValue aValue) {
            if (TryGetValue(aKey, out var possibles))
                return possibles.TryGetValue(aKey, out aValue);
            else {
                aValue = default(TValue);
                return false;
            }
        }
    
        public ICollection<string> KeysCS => Values.SelectMany(v => v.Keys).ToList();
    
        public IndexerPropertyAtCS AtCS
        {
            get => new IndexerPropertyAtCS(this);
            set => new IndexerPropertyAtCS(this);
        }
    
        public class IndexerPropertyAtCS {
            CaseDictionary<TValue> myDict;
    
            public IndexerPropertyAtCS(CaseDictionary<TValue> d) => myDict = d;
    
            public TValue this[string aKey]
            {
                get
                {
                    if (myDict.TryGetValueCS(aKey, out var theValue))
                        return theValue;
                    else
                        throw new KeyNotFoundException();
                }
                set
                {
                    if (myDict.TryGetValue(aKey, out var possibles))
                        possibles[aKey] = value;
                    else
                        myDict.Add(aKey, value);
                }
            }
        }    
    }
