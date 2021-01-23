    public class Connection: IDisposable
        {
            private static SqlConnectionStringBuilder ConnectionString(string dbName)
            {
                return new SqlConnectionStringBuilder
                {
                    ApplicationName = "Apllication Name",
                    DataSource = @"Your source",
                    IntegratedSecurity = false,
                    InitialCatalog = Database Name,
                    Password = "Your Password",
                    PersistSecurityInfo = false,
                    UserID = "User Id",
                    Pooling = true
                };
            }
    
            protected static IDbConnection LiveConnection(string dbName)
            {
                var connection = OpenConnection(ConnectionString(dbName));
                connection.Open();
                return connection;
            }
    
            private static IDbConnection OpenConnection(DbConnectionStringBuilder connectionString)
            {
                return new SqlConnection(connectionString.ConnectionString);
            }
    
            protected static bool CloseConnection(IDbConnection connection)
            {
                if (connection.State != ConnectionState.Closed)
                {
                    connection.Close();
                   // connection.Dispose();
                }
                return true;
            }
            private static void ClearPool()
            {
                SqlConnection.ClearAllPools();
            }
    
            public void Dispose()
            {
                ClearPool();
            }
        }
    }
