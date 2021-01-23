    public void Insert(List<string> nomList){
        foreach(string nominal in nomList)
        {
            SqlCommand dbCommand = new SqlCommand();
            dbCommand.CommandText = "INSERT INTO Brand (BrandName)VALUES (@BrandName)";
            dbCommand.Connection = conn;
            da = new SqlDataAdapter();
            da.SelectCommand = dbCommand;
            dbCommand.Parameters.AddWithValue("@BrandName", nominal);
            dbCommand.ExecuteNonQuery()
        }
    }
