    public static class SessionFacade
    {
        /// <summary>
        /// Gets the database connection string.
        /// </summary>
        public static string DatabaseConnectionString => Environment.GetEnvironmentVariable("Database:Connection");
    
        public static string DatabasePostgresConnectionString => Environment.GetEnvironmentVariable("DatabasePostgres:Connection");
    
        public static Dictionary<DbConnectionSessionType, ISessionFactory> DatabaseSessionFactories
        {
            set; get;
        } = new Dictionary<DbConnectionSessionType, ISessionFactory>() {
            {
                DbConnectionSessionType.MsqlSession,
                null
            },
            {
                DbConnectionSessionType.PostgresqlSession,
                null
            }
        };
    }
