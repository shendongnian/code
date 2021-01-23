    public void Insert(List<string> nomList){
        StringBuilder sb = new StringBuilder();
        foreach(string nominal in nomList)
        {
            sb.Append(nominal + ";");
        }
            SqlCommand dbCommand = new SqlCommand();
            dbCommand.CommandText = "INSERT INTO Brand (BrandName)VALUES (@BrandName)";
            dbCommand.Connection = conn;
            da = new SqlDataAdapter();
            da.SelectCommand = dbCommand;
            dbCommand.Parameters.AddWithValue("@BrandName", sb.ToString());
            dbCommand.ExecuteNonQuery()
    }
