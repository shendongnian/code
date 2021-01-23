    using (SqlConnection connection = new SqlConnection(connectionString))
    using (SqlCommand command = connection.CreateCommand())
    {
        command.CommandText = commandText;
    
        command.Parameters.Add("@Id", SqlDbType.Int, 4).Value = id;
        command.Parameters.Add("@StartTime", SqlDbType.DateTime, 8).Value =  DateTime.Now;
    
       if (!(cmd.ExecuteNonQuery() > 0))
           throw new Exception("Domain id was not stored");
    }
