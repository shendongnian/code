    public interface IDatabaseSessions
    {
        ISession MssqlSession { get; set; }
        ISession PostgresqlSession { get; set; }
    }
