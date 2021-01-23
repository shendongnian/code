    public class EnumDictionary<TKey, TValue>
    {
        private Dictionary<TKey, TValue> _Dict;
        private readonly IEqualityComparer<TValue> _cmp;
        public EnumDictionary(Dictionary<TKey, TValue> Dict, IEqualityComparer<TValue> cmp)
        {
            this._Dict = Dict;
            _cmp = cmp;
        }
        public EnumDictionary(Dictionary<TKey, TValue> Dict)
            :this(Dict, IEqualityComparer<TValue>.Default){}
        public TKey GetValue(TValue value)
        {
            foreach (KeyValuePair<TKey, TValue> kvp in _Dict)
            {
                if (cmp.Equals(kvp.Value, value))
                    return kvp.Key;
            }
            throw new Exception("Undefined data type: " + value);
        }              
    }
