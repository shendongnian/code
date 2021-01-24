    public class DatabaseFactory
    {
        private Config _config;
    
        public DatabaseFactory(Config config)
        {
            _config = config;
        }
    
        public Database getDatabase()
        {
            var databaseType = _config.GetDatabaseType();
    
            Database database = null;
    
            switch (databaseType)
            {
            case DatabaseEnum.MySQL:
                database = new MyMySQLDatabase(new CSharpMySQLDriver());
                break;
            case DatabaseEnum.MSSQL:
                database = new MyMSSQLDatabase(new CSharpMSSQLDriver());
                break;
            case DatabaseEnum.PostgreSQL:
                database = new MyPostgreSQLDatabase(new CSharpPostgreSQLDriver());
                break;
            default:
                throw new DatabaseDriverNotImplementedException();
                break;
            }
    
            return database;
        }
    }
