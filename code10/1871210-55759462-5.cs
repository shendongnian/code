    public class Repository<T> : IRepository<T> where T : Entity
    {
        public Repository(IDatabaseSessions databaseSessions, DbConnectionSessionType connectionType = DbConnectionSessionType.PostgresqlSession)
                {
                    if(connectionType == DbConnectionSessionType.MsqlSession) _session = databaseSessions.MssqlSession;
                    if(connectionType == DbConnectionSessionType.PostgresqlSession) _session = databaseSessions.PostgresqlSession;
                }
        }
    }
