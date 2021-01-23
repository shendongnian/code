    using(var connection = GetOpenConnection()) {
        using(var cmd = connection.CreateCommand()){
            cmd.CommandText = "Status_Insert";
            cmd.CommandType = CommandType.StoredProcedure;
    
            var prmReturnValue = new SqlParameter( "@ReturnValue", DBNull.Value );
            prmReturnValue.Direction = ParameterDirection.ReturnValue;
    
            using(var reader = cmd.ExecuteReader()) {
                // process table result(s)
            }
    
            var returnValue = prmReturnValue.Value;
        }
    }
