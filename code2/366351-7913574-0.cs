    private DataTable OpenDataStream(String sql)
    {
        DataTable dt = new DataTable();
        SqlCommand sqlComm = new SqlCommand();
        sqlComm.Connection = new SqlConnection();
        sqlComm.Connection.ConnectionString = @"Myconnectionstring";
        sqlComm.CommandText = sql;
        sqlComm.Connection.Open();
        SqlDataReader data = null;
        data = sqlComm.ExecuteReader();
        dt.Load(data);
        data.Close();
        return dt;
    }
