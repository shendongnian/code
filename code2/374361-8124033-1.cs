    using (OracleConnection connection = new OracleConnection("connstring"))
    using (OracleCommand command = connection.CreateCommand()) {
      command.CommandType = CommandType.StoredProcedure;
      command.CommandText = "TEST_SCHEMA.TEST_PROCEDURE";
      command.Parameters.Add("out_DATA", OracleType.Cursor)
          .Direction = ParameterDirection.Output;
      connection.Open();
      command.ExecuteNonQuery();
      OracleDataReader reader = 
          command.Parameters["out_DATA"].Value as OracleDataReader;
      if (reader != null) {
        using (reader) {
          while(reader.Read()) {
            string col1 = reader["col1"] as string;
            string col2 = reader["col2"] as string;
          }
        }
      }
    }
