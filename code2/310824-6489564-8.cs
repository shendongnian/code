        [WebMethod]
    public DataSet Insert(string nominal)
    {        
        SqlCommand dbCommand = new SqlCommand();
        dbCommand.CommandText = "INSERT INTO Brand (BrandName)VALUES (@BrandName)";
        dbCommand.Connection = conn;
        dbCommand.Parameters.AddWithValue("@BrandName", sb.ToString());
        dbCommand.ExecuteNonQuery();
        SqlCommand dbCommand = new SqlCommand();
        dbCommand.CommandText = "SELECT * FROM Brand";
        dbCommand.Connection = conn;
        da = new SqlDataAdapter();
        da.SelectCommand = dbCommand;
        dbCommand.ExecuteNonQuery();
    
        DataSet ds = new DataSet();
        da.Fill(ds);
        return ds;
    }
