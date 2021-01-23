    using (SqlConnection connection = new SqlConnection(connectionString))
    {
     using(SqlCommand command = connection.GetCommand(queryString, CommandType.Text))
     {
      command.Parameters.Add(new SqlParameter("AnnID", id));
      command.Parameters.Add(new SqlParameter("AnnTitle", title));
      ............
      ..............
      command.Connection.Open();
      command.ExecuteNonQuery();
     }
    }
