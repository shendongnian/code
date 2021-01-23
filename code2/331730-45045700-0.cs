    public class Acessor<TKey, TValue>
        where TKey : IComparable
        where TValue : class
    {
        Dictionary<TKey, TValue> myElements = new Dictionary<TKey, TValue>();
        public TValue this[TKey key]
        {
            get
            {
                return myElements[key];
            }
            set
            {
                myElements.Add(key, value);
            }
        }
    }
