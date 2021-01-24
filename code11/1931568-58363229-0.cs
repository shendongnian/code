    public sealed class ObjectDictionary<TKey> : Dictionary<TKey, object>
    {
        private readonly object _cached_0 = 0;
        private readonly object _cached_false = false;
        public new void Add(TKey key, object value)
        {
            if (value is int && (int)value == 0)
            {
                base.Add(key, _cached_0);
            }
            else if (value is bool && (bool)value == false)
            {
                base.Add(key, _cached_false);
            }
            else
            {
                base.Add(key, value);
            }
        }
    }
