    string tableName = "get value from dropdown";  
    DataTable dt = new DataTable();
    using (SqlConnection conn = new SqlConnection("connection string here"))
    {
        string sql = string.Format("select * from {0}", tableName);
        SqlDataAdapter da = new SqlDataAdapter(sql, conn);
        da.Fill(dt);
    }
    // bind dt to your grid or gui component here.
