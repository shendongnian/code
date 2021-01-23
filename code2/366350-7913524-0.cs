    private DataTable GetDataTable(String sql)
    {
        SqlDataAdapter da = new SqlDataAdapter(sql, connection);
        DataSet ds = new DataSet();
        da.Fill(ds);
        return ds.Tables[0];
    }
