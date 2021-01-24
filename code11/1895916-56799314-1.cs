    //***
    // Enhanced Dictionary that auto-creates missing values as default
    // ala auto-vivification in Perl
    //***
    public class AutoDictionary<TKey, TValue> : Dictionary<TKey, TValue> {
        public AutoDictionary() : base() { }
        public AutoDictionary(IDictionary<TKey, TValue> d) : base() {
            foreach (var kvp in d)
                Add(kvp.Key, kvp.Value);
        }
    
        public new TValue this[TKey key]
        {
            get
            {
                if (!TryGetValue(key, out var val))
                    base[key] = val;
                return val;
            }
            set => base[key] = value;
        }
    }
