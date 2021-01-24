    public struct KeyValueGeneric<TKey, TValue>
    {
        public readonly TKey Key;
        public readonly TValue Value;
        public KeyValueGeneric(TKey key, TValue value)
        {
            Key = key;
            Value = value;
        }
    }
