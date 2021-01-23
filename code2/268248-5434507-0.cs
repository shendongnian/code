    public class TableServiceContext<T>
    {
        public TableServiceContext(string baseAddress, StorageCredentials credentials)
            : base(baseAddress, credentials)
        {
        }
        public string TableName { get { return typeof(T).Name; } }
        public IQueryable<T> Table
        {
            get
            {
                return this.CreateQuery<T>(TableName);
            }
        }
    }
