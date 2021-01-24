    public static class DB
    {
        private static string connectionString = "connection string here";
        public static IEnumerable<IDataRecord> QueryResult(string Query, params MySqlParameter[] parameters)
        {
            using (var conn = new MySqlConnection(connectionString))
            using (var cmd = new MySqlCommand(Query, conn))
            {
                if (parameters is object && parameters.Length > 0)
                {
                    cmd.Parameters.AddRange(parameters);
                }
                conn.Open();
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        yield return reader;
                    }
                }
            }
        }
    }
