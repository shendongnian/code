    public class MyAppSettings<TKey, TValue> : Dictionary<TKey, TValue>
    {
        public void TryGetValue(TKey key, out TValue value, TValue defaultValue)
        {
            if (!this.TryGetValue(key, out value))
            {
                value = defaultValue;
            }
        }
    }
