        public static class CustomDatabaseFactory
        {
            static readonly DbProviderFactory dbProviderFactory = DbProviderFactories.GetFactory("System.Data.SqlClient");
            
            public static Database CreateDatabase(string connectionString)
            {
                return new GenericDatabase(connectionString, dbProviderFactory);
            }
        }
