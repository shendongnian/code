    // assume a DB2Connection conn
    DB2Transaction trans = conn.BeginTransaction();
    DB2Command cmd = conn.CreateCommand();
    String procName = "INOUT_PARAM";
    String procCall = "CALL INOUT_PARAM (@param1, @param2, @param3)";
    cmd.Transaction = trans;
    cmd.CommandType = CommandType.Text;
    cmd.CommandText = procCall;
    
    // Register input-output and output parameters for the DB2Command
    cmd.Parameters.Add( new DB2Parameter("@param1", "Value1");
    cmd.Parameters.Add( new DB2Parameter("@param2", "Value2");
    DB2Parameter param3 = new DB2Parameter("@param3", IfxType.Integer);
    param3.Direction = ParameterDirection.Output;
    cmd.Parameters.Add( param3 );
    
    // Call the stored procedure
    Console.WriteLine("  Call stored procedure named " + procName);
    cmd.ExecuteNonQuery();
        // Register input-output and output parameters for the DB2Command
        ...
        
        // Call the stored procedure
        Console.WriteLine("  Call stored procedure named " + procName);
        cmd.ExecuteNonQuery();
