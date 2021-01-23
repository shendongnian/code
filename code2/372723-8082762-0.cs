    public class WhereOrCondition<T> : WhereCondition<T> where T : DatabaseObject { }
    public class WhereCondition<T> : IEnumerable<KeyValuePair<string, object>> where T : DatabaseObject
    {
        public IEnumerator<KeyValuePair<string, object>> GetEnumerator() { }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    public class DatabaseObject { }
