    using (var connection = new SqlConnection(/* some connection info */))
    using (var command = new SqlCommand(sql, connection))
    {
      var idParameter = new SqlParameter("id", SqlDbType.int); // change here
      idParameter.Value = 10;
      command.Parameters.Add(idParameter);
      var results = command.ExecuteReader();
    }
