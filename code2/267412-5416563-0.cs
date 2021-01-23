    public class InjectiveDictionary<T, V> : Dictionary<T, V>
    {
        public new void Add(T key, V value)
        {
            if (this.ContainsValue(value))
            {
                throw new Exception("value already used");
            }
            base.Add(key, value);
        }
    }
