    public class MyDictionary : IDictionary<TKey, TValue>
    {
        public MyDictionary()
        {
            Contract.Requires(typeof(TKey) != typeof(TValue));
        }
    }
