        private OleDbConnection OpenDbConnection()
        {
            string connectionString = GetConnectionString();
            OleDbConnection conn = new OleDbConnection {ConnectionString = connectionString};
            conn.Open();
            return conn;
        }
