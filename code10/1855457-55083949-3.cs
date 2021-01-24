    static class Sql
    {
        public static void ExecuteSql(string connectionName, string sql)
        {
            using (var connection = new SqlConnection(GetConnectionString(connectionName)))
            {
                using (var command = new SqlCommand(sql, connection))
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }
        public static T ExecuteScalar<T>(string connectionName, string sql)
        {
            using (var connection = new SqlConnection(GetConnectionString(connectionName)))
            {
                using (var command = new SqlCommand(sql, connection))
                {
                    connection.Open();
                    return (T)command.ExecuteScalar();
                }
            }
        }
        public static string GetConnectionString(string connectionName)
        {
            return ConfigurationManager.ConnectionStrings[connectionName].ConnectionString;
        }
    }
