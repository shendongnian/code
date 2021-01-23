        public void add2Db(string table, string sqlRows, string sqlValues)
        {
            string sql = "INSERT INTO " + table + " (" + sqlRows + ") VALUES (" + sqlValues + ")";
            using(SqlConnection dbConn = new SqlConnection(ConfigurationManager.ConnectionStrings["LocalSqlServer"].ToString())
            {
                 SqlCommand cmd = new SqlCommand(sql, dbConn);
                 cmd.CommandType = CommandType.Text;
                 cmd.ExecuteNonQuery();
            }
        }
