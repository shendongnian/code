    public DataSet GetDataSet(string ConnectionString, string SQL)
    {
        SqlConnection conn = new SqlConnection(ConnectionString);
        SqlDataAdapter da = new SqlDataAdapter();
        SqlCommand cmd = conn.CreateCommand();
        cmd.CommandText = SQL;
        da.SelectCommand = cmd;
        DataSet ds = new DataSet();
    
        conn.Open();
        da.Fill(ds);
        conn.Close();
    
        return ds;
    }
