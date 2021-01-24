    public class SortOrderProvider : ISortOrderProvider
    {
        private const string DefaultKey = "__default";
        private readonly Dictionary<(Type, string), object> _rules = new Dictionary<(System.Type, string), object>();
        public void Add<T>(string name, ISortOrderRule<T> sortOrderRule)
        {
            _rules[(typeof(T), name)] = sortOrderRule;
    
            if (sortOrderRule.IsDefault)
                _rules[(typeof(T), DefaultKey)] = sortOrderRule;
        }
        public ISortOrderRule<T> Get<T>(string name)
        {
            if (_rules.TryGetValue((typeof(T), name), out var value))
                return (ISortOrderRule<T>)value;
            return GetDefault<T>();
        }
        public ISortOrderRule<T> GetDefault<T>()
        {
            if (_rules.TryGetValue((typeof(T), DefaultKey), out var value))
                return (ISortOrderRule<T>)value;
            else
                return null;
        }
    }
