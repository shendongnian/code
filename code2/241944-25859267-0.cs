    public static class DbConnectionExtensions
    {
        public static bool TableExists(this DbConnection conn, string table)
        {
            return conn.GetSchema("Tables", new string[4] { null, null, table, "TABLE" }).Rows.Count > 0;
        }
    }
