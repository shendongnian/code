    public class DatabaseSessions: IDatabaseSessions
    {
        public DatabaseSessions()
        {
            MssqlSession = SessionFacade.DatabaseSessionFactories[DbConnectionSessionType.MsqlSession].OpenSession();
            PostgresqlSession = SessionFacade.DatabaseSessionFactories[DbConnectionSessionType.PostgresqlSession].OpenSession();
        }
    
        public ISession MssqlSession { get; set; }
        public ISession PostgresqlSession { get; set; }
    }
