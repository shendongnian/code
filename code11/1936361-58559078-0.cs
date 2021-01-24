        internal DataTable FindTrusts()
        {
            ValidateEnvironment();
            DataTable dt = new DataTable();
            string selectStatement = @"SELECT * FROM Test ORDER BY TestId ASC";
            SqlConn.Open();
            SqlCommand cmd = new SqlCommand(selectStatement, SqlConn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            SqlConn.Close();
            return dt;
        }
