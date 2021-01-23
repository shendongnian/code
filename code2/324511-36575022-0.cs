    [JsonObject]
    public class MyKeyValuePair<TKey, TValue>
    {
        public TKey MyKey;
        public TValue MyValue;
        [JsonConstructor]
        public MyKeyValuePair()
        {
        }
        public MyKeyValuePair(TKey t1, TValue t2)
        {
            MyKey = t1;
            MyValue = t2;
        }
    }
    [JsonObject]
    public class MyDictionaty<TKey, TValue>
    {
        public ICollection<MyKeyValuePair<TKey, TValue>> Collection;
        [JsonConstructor]
        public MyDictionaty()
        {
            
        }
        public MyDictionaty(Dictionary<TKey, TValue> refund)
        {
            Collection = BuildMyKeyValuePairCollection(refund);
        }
        internal Dictionary<TKey, TValue> ToDictionary()
        {
            return Collection.ToDictionary(pair => pair.MyKey, pair => pair.MyValue);
        }
        private ICollection<MyKeyValuePair<TKey, TValue>> BuildMyKeyValuePairCollection(Dictionary<TKey, TValue> refund)
        {
            return refund.Select(o => new MyKeyValuePair<TKey, TValue>(o.Key, o.Value)).ToList();
        }
    }
    [JsonObject]
    public class ClassWithDictionary
    {
        [JsonProperty]
        private readonly MyDictionary<AnyKey, AnyValue> _myDictionary;
        private Dictionary<AnyKey, AnyValue> _dic;
        [JsonConstructor]
        public ClassWithDictionary()
        {
            
        }
        public ClassWithDictionary(Dictionary<AnyKey, AnyValue> dic)
        {
            _dic= dic;
            _myDictionary = new MyDictionaty<AnyKey, AnyValue>(dic);
        }
        public Dictionary<AnyKey, AnyValue> GetTheDictionary()
        {
            _dic = _dic??_myDictionary.ToDictionary();
            return _dic;
        }
    }
