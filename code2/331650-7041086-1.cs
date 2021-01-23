    class MyDictionary<TKey, TValue> : IDictionary<TKey, TValue> 
    {
        private Dictionary<TKey, TValue> d;
    
        public void Add(TKey key, TValue value)
        {
            if( value.GetType().IsSerializable )
            {
                d.Add(key, value);
            }
            else 
            {
                throw new ArgumentException();
            }
        }
        .....
    }
