    public abstract class DbClass<T> where T : DbClass<T>, new()
    {
        protected abstract String FetchQuery { get; }
        protected abstract void Initialize(DatabaseRecord row);
        public static T FetchObject(DatabaseSession dbSession, Int32 key)
        {
            DatabaseRecord record = dbSession.RetrieveRecord(FetchQuery, parameters);
            T obj = new T();
            obj.Initialize(row);
            return obj;
        }
    }
