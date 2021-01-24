     public partial class MySqlDBContext : DbContext
        {
            public MySqlDBContext(string FirstSQLServerDBContext)
                : base(configmanager.connectionstrings(FirstSQLServerDBContext)...)
            {
            }
