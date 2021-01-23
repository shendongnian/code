    DataTable tbl = new DataTable();
    using(var conn = new SqlConnection(@"Data Source=..."))
    using(var com = conn.CreateCommand())
    {
        com.CommandText = "select * from tbl1 where id<@id";
        com.Parameters.AddWithValue("@id",4);
        com.CommandType = CommandType.Text;        
        SqlDataAdapter dap = new SqlDataAdapter();   
        dap.SelectCommand = com;
        conn.Open();
        dap.Fill(tbl);
        conn.Close();     
    }
    return tbl;
