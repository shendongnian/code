        SqlConnection SqlConnection = new SqlConnection(connectionString);
        SqlCommand SqlCommand = new SqlCommand();
        SqlCommand.CommandText = "update products set [UnitPrice] = '100' where [ProductName] = '" + keyvalue + "'";
        SqlCommand.Connection = SqlConnection;
        SqlConnection.Open();
        SqlCommand.ExecuteNonQuery();
        SqlConnection.Close();
