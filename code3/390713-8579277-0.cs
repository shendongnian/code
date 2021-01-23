    static class Program
    {
        static void Main(string[] args)
        {
            var connStr = new SqlConnectionStringBuilder
            {
                DataSource = "localhost",
                InitialCatalog = "RichTest",
                IntegratedSecurity = true
            };
            using (var conn = new SqlConnection(connStr.ToString()))
            {
                conn.Open();
                var parents = GetPrimaryKeysForTable(conn, "People");
                Console.WriteLine("Parent Keys:");
                foreach (var p in parents)
                {
                    Console.WriteLine("  {0}", p);
                }
            }
        }
        static IList<string> GetPrimaryKeysForTable(SqlConnection conn, string tableName)
        {
            if (conn == null) throw new ArgumentNullException("Value is null", "conn");
            if (string.IsNullOrWhiteSpace(tableName)) throw new ArgumentNullException("Value is null or emtpy", "tableName");
            List<String> retVal = new List<string>();
            using (var command = new SqlCommand
            {
                Connection = conn,
                CommandText = "sp_pkeys",
                CommandType = CommandType.StoredProcedure
            })
            {
                command.Parameters.AddWithValue("@table_name", typeof(SqlChars)).Value = tableName;
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    retVal.Add(reader["COLUMN_NAME"].ToString());
                }
            }
            return retVal;
        }
    }
