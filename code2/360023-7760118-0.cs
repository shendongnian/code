    int result;
    using (SqlConnection connection = new SqlConnection(myconnectionString)) {
      using (SqlCommand command = new SqlCommand(connection)) {
        command.CommandType = CommandType.StoredProcedure;
        command.CommandText = "usp_GetCustomer";
        command.Parameters.Add("@username", DbType.VarChar).Value = username;
        command.Parameters.Add("@month", DbType.VarChar).Value = month;
        connection.Open();
        result = (int)myCommand.ExecuteScalar();
      }
    }
