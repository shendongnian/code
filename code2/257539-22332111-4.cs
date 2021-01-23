    public class MsSqlDatabaseTestsHelper
    {
        private readonly string _connectionString;
        public MsSqlDatabaseTestsHelper(string connectionString)
        {
            _connectionString = connectionString;
        }
        private void ExecuteNonQuery(string sql)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                SqlCommand command = connection.CreateCommand();
                command.CommandText = sql;
                command.ExecuteNonQuery();
            }
        }
        public void CreateDatabase(string databaseName)
        {
            ExecuteNonQuery("CREATE DATABASE {0}".Set(databaseName));
        }
        public void DropDatabase(string databaseName)
        {
            try
            {
                ExecuteNonQuery(Resources.SQL_KillConnections
                    .Set(databaseName));
            }
            catch (Exception)
            {
                throw new Exception("Can't kill database '{0}' connections"
                    .Set(databaseName));
            }
            try
            {
                ExecuteNonQuery(Resources.SQL_DropDatabaseIfExists
                    .Set(databaseName));
            }
            catch (Exception)
            {
                throw new Exception("Can't drop database '{0}'"
                    .Set(databaseName));
            }
        }
    }
