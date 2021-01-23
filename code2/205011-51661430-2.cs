    using (OracleConnection connection = new OracleConnection("ConnectionString"))
        using (OracleCommand command = new OracleCommand("ProcName", connection))             
        {
              command.CommandType = CommandType.StoredProcedure;
              command.Parameters.Add("ParameterName", OracleDbType.Varchar2).Value = "Your Data Here";
              command.Parameters.Add("SomeOutVar", OracleDbType.Varchar2, 120);
              command.Parameters["return_out"].Direction = ParameterDirection.Output;
              command.Parameters.Add("SomeOutVar1", OracleDbType.Varchar2, 120);
              command.Parameters["return_out2"].Direction = ParameterDirection.Output;
              connection.Open();
              command.ExecuteNonQuery();
              string SomeOutVar = command.Parameters["SomeOutVar"].Value.ToString();
              string SomeOutVar1 = command.Parameters["SomeOutVar1"].Value.ToString();
        }
