    //***
    // Enhanced Dictionary that auto-creates missing values with seed lambda
    // ala auto-vivification in Perl
    //***
    public class SeedDictionary<TKey, TValue> : Dictionary<TKey, TValue> {
        Func<TValue> seedFn;
        public SeedDictionary(Func<TValue> pSeedFn) : base() {
            seedFn = pSeedFn;
        }
        public SeedDictionary(Func<TValue> pSeedFn, IDictionary<TKey, TValue> d) : base() {
            seedFn = pSeedFn;
            foreach (var kvp in d)
                Add(kvp.Key, kvp.Value);
        }
    
        public new TValue this[TKey key]
        {
            get
            {
                if (!TryGetValue(key, out var val))
                    base[key] = (val = seedFn());
                return val;
            }
            set => base[key] = value;
        }
    }
