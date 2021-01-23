        public class ProfiledDbProviderFactoryForEntLib : ProfiledDbProviderFactory
        {
            private DbProviderFactory _tail;
            public static ProfiledDbProviderFactory Instance = new ProfiledDbProviderFactoryForEntLib();
            public ProfiledDbProviderFactoryForEntLib(): base(null, null)
            {
            }
            public void InitProfiledDbProviderFactory(IDbProfiler profiler, DbProviderFactory tail)
            {
                base.InitProfiledDbProviderFactory(profiler, tail);
                _tail = tail;
            }
            public override DbDataAdapter CreateDataAdapter()
            {
                return new DbDataAdapterForEntLib(base.CreateDataAdapter());
            }
            public override DbCommand CreateCommand()
            {
                return _tail.CreateCommand(); 
            }        
        }
                 
        public class DbDataAdapterForEntLib : DbDataAdapter
        {
            private DbDataAdapter _dbDataAdapter;
            public DbDataAdapterForEntLib(DbDataAdapter adapter)
            : base(adapter)
           {
                _dbDataAdapter = adapter;
           }
        }
