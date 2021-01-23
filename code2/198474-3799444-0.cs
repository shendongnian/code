    class RandomDictionary<TKey, TValue>
    {
        Dictionary<TKey, TValue[]> m_dict;
        Random m_random;
    
        public RandomDictionary()
        {
            m_dict = new Dictionary<TKey, TValue[]>();
            m_random = new Random();
        }
    
        public TValue this[TKey key]
        {
            get
            {
                TValue[] values = m_dict[key];
                return values[m_random.Next(0, values.Length)];
            }
        }
    
        public void Define(TKey key, params TValue[] values)
        {
            m_dict[key] = new TValue[values.Length];
            Array.Copy(values, m_dict[key], values.Length);
        }
        public bool TryGetValue(TKey key, out TValue value)
        {
            TValue[] values;
            if (!m_dict.TryGetValue(key, out values))
            {
                value = default(TValue);
                return false;
            }
            value = values[m_random.Next(0, values.Length)];
            return true;
        }
    }
