    [Immutable]
    class ImmutableDictionary<TKey, TValue> : Dictionary<TKey, TValue>
    {
        public ImmutableDictionary(IEnumerable<KeyValuePair<TKey, TValue>> keysValues)
        {
            // Ensure TKey is immutable...
            if (typeof(TKey).GetCustomAttribute(typeof(ImmutableAttribute), false).Length == 0)
                throw new InvalidOperationException(String.Format("Type '{0}' must be immutable.", typeof(TKey).AssemblyQualifiedName);
            // Ensure TValue is immutable...
            if (typeof(TValue).GetCustomAttribute(typeof(ImmutableAttribute), false).Length == 0)
                throw new InvalidOperationException(String.Format("Type '{0}' must be immutable.", typeof(TValue).AssemblyQualifiedName);
            foreach(var keyValue in keysValues)
                base.Add(keyValue.Key, keyValue.Value);
        }
        public new void Add(TKey key, TValue value)
        {
            throw new InvalidOperationException("Cannot modify contents of immutable dictionary.");
        }
        public new void Clear()
        {
            throw new InvalidOperationException("Cannot modify contents of immutable dictionary.");
        }
        public new void Remove(TKey key)
        {
            throw new InvalidOperationException("Cannot modify contents of immutable dictionary.");
        }
        public TValue this[TKey key]
        {
            get { return base[key]; }
            set
            {
                throw new InvalidOperationException("Cannot modify contents of immutable dictionary.");
            }
        }
    }
