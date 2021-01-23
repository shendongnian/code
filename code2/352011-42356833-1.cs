      command.CommandType = CommandType.StoredProcedure;
      param = new SqlParameter("@COUNTRY", "Germany");
      param.Direction = ParameterDirection.Input;
      param.DbType = DbType.String;
      command.Parameters.Add(param);
