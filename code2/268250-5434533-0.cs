    public class ServiceContext<T> : TableServiceContext
    {
        public ServiceContext(string baseAddress, StorageCredentials credentials)
            : base(baseAddress, credentials)
        {
        }
        public IQueryable<T> Table
        {
            get
            {
                return this.CreateQuery<T>(typeof(T).Name);
            }
        }
    
    }
