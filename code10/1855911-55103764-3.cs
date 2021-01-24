    public static object ExecuteScalar(SqlConnection connection, CommandType commandType, string commandText)
    {
        //pass through the call providing null for the set of SqlParameters
        return ExecuteScalar(connection, commandType, commandText, (SqlParameter[])null);
    }
