    internal class QueryBuilder<T> : IQueryBuilder<T> where T : class
    {
        private static readonly string KeyField = ((ModelAttributes)typeof(T).GetCustomAttributes(false).Where(x => x == (ModelAttributes)x).First()).Key;
        private string _Query = string.Empty;
        public string SelectByID(int ID)
        {
            // don't create your query this way.  use a parameterized query
            _Query = string.Format("SELECT * FROM {0} WHERE {1} = '{2}'", typeof(T).Name, KeyField, ID);
            return _Query;
        }
    }
