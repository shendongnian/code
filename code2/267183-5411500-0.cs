    public class OrderedDictionary<TKey, TValue> : IDictionary<TKey, TValue> {
        private OrderedDictionary backing = new OrderedDictionary();
    
        // for each IDictionary<TKey, TValue> method, simply call that method in 
        // OrderedDictionary, performing the casts manually. Also duplicate any of 
        // the index-based methods from OrderedDictionary that you need.
        void Add(TKey key, TValue value)
        {
            this.backing.Add(key, value);
        }
        bool TryGetValue(TKey key, out TValue value)
        {
            object objValue;
            bool result = this.backing.TryGetValue(key, out objValue);
            value = (TValue)objValue;
            return result;
        }
        TValue this[TKey key]
        {
            get
            {
                return (TValue)this.backing[key];
            }
            set
            {
                this.backing[key] = value;
            }
        }
    }
