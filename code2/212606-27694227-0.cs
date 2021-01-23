     using (SqlConnection connection = new SqlConnection(this.Connection.ConnectionString))
    {
      connection.Open();
      SqlCommand command = new SqlCommand(query, connection);
      SqlDataReader reader = command.ExecuteReader();
      
      reader.Cast<IDataRecord>().AsQueryable().Dump();		
    }
