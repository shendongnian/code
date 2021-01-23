    public class ServiceContext<T> : TableServiceContext
    {
        public ServiceContext(string baseAddress, StorageCredentials credentials)
            : base(baseAddress, credentials)
        {
        }
        public const string TableName = typeof(T).Name;
        public IQueryable<T> Table
        {
            get
            {
                return this.CreateQuery<T>(TableName);
            }
        }
    }
