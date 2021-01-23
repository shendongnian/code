     public static class DbConnectionFactory
    {
        public static ConnectionStringSettings AppConnectionSettings = ConfigurationManager.ConnectionStrings["{A connection string name}"];
        public static SqlConnectionStringBuilder AppConnBuilder = new SqlConnectionStringBuilder(AppConnectionSettings.ConnectionString);
        public static string DbUserID
        {
            get
            {
                return AppConnBuilder.UserID;
            }
            set { }
        }
    }
