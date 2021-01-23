        [WebMethod]
    public DataSet Insert(string nominal)
    {        
        SqlCommand dbCommand = new SqlCommand();
        dbCommand.CommandText = "INSERT INTO Brand (BrandName)VALUES (@BrandName)";
        dbCommand.Connection = conn;
        dbCommand.Parameters.AddWithValue("@BrandName", sb.ToString());
        dbCommand.ExecuteNonQuery();
        SqlCommand dbCommand2 = new SqlCommand();
        dbCommand2.CommandText = "SELECT * FROM Brand";
        dbCommand2.Connection = conn;
        SqlDataAdapter da = new SqlDataAdapter();
        da.SelectCommand = dbCommand2;
        dbCommand2.ExecuteNonQuery();
    
        DataSet ds = new DataSet();
        da.Fill(ds);
        return ds;
    }
