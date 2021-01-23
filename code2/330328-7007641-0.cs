    var command = new SqlCommand("MyQuery", connection);
    command.CommandType = CommandType.StoredProcedure;
    
    var param = command.CreateParameter();
    param.Name = "@Test";
    param.Type = DbType.Int;
    param.Direction = ParameterDirection.InputOutput;
    param.Value = 1;
