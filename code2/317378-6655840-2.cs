    public class ReadOnlyDictionary<TKey, TValue>
    {
        Dictionary<TKey, TValue> innerDictionary;
        public virtual TValue this[TKey key]
        {
            get
            {
                return innerDictionary[key];
            }
            private set
            {
                innerDictionary[key] = value;
            }
        }
    }
