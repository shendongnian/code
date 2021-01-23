    public class KeyValue<TKey, TValue>
    {
        public TKey Key { get; set; }
        public TValue Value { get; set; }
    }
    public Dictionary<TKey, TValue> GetKeyValue<TKey, TValue>(Expression<Func<TEntity, KeyValue<TKey, TValue>>> keySelector)
    {
        return _dbset.Select(keySelector).ToDictionary(x => x.Key, x => x.Value);
    }
    public Dictionary<int, string>  GetIndustriesKeyValue()
    {
        return IndustryRepository.GetKeyValue(x => new KeyValue<int, string> {Key = x.Id, Value = x.Name});
    }
