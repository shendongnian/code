    public static class RepositoryFactory
    {
        internal static Hashtable Repositories = new Hashtable();
        internal static T GetRepository<T>() where T : class, new()
        {
            if (Repositories[typeof(T)] as T == null)
            {
                Repositories[typeof(T)] = new T();
            }
            return Repositories[typeof(T)] as T;
        }
        public static AccountTypeRepository AccountTypeRepository
        {
            get { return GetRepository<AccountTypeRepository>(); } 
        }
        public static BankRepository BankRepository
        {
            get { return GetRepository<BankRepository>(); } 
        }
        /* repeat as needed or change accessibility and call GetRepository<> directly */
