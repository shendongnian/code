    public static class DictHandler
    {
        public static DictHandler<T, TKey, TValue> CreateHandler<T, TKey, TValue>
            (T dictionary1, Dictionary<TKey, TValue> dictionary2)
            where T : Dictionary<TKey, TValue>
        {
            return new DictHandler<T, TKey, TValue>();
        }
    }
    public class DictHandler<T, TKey, TValue> where T : Dictionary<TKey, TValue>
    {
    }
