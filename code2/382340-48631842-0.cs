    public interface IResultSet
    {
        long TotalItems { get; }
        IEnumerable Items { get; }
    }
    public class ResultSet<T> : IResultSet, IEnumerable<T>
    {
        private IEnumerable<T> _enumerable;
        private int _totalItems;
        public ResultSet(IEnumerable<T> enumerable,
                         int totalItems)
        {
            _enumerable = enumerable;
            _totalItems = totalItems;
        }
        public IEnumerable Items { get { return _enumerable; } }
        public long TotalItems { get{ return _totalItems; } }
        public IEnumerator<T> GetEnumerator()
        {
            return _enumerable.GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return _enumerable.GetEnumerator();
        }
    }
    public class ResultSetConverter : JavaScriptConverter
    {
        public override IEnumerable<Type> SupportedTypes
        {
            get
            {
                return new[] { typeof(IResultSet) };
            }
        }
        ...
        public override IDictionary<string, object> Serialize(object obj, JavaScriptSerializer serializer)
        {
            if (!typeof(IResultSet).IsAssignableFrom(obj.GetType()))
            {
                return null;
            }
            var resultSet = obj as IResultSet;
            var json = new Dictionary<string, object>();
  
            json["totalItems"] = resultSet.TotalItems;
            json["items"] = resultSet.Items;
            return json;
        }
    }
