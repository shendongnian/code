    public static SqlParameter[] GetSqlParameters(SqlConnection
    connection, SqlTransaction transaction, string spName, params object[]
    parameterValues)
    {
        if ((parameterValues != null) && (parameterValues.Length > 0)) 
        {
            SqlParameter[] commandParameters =
    SqlHelperParameterCache.GetSpParameterSet(connection.ConnectionString,
    spName);
    
            AssignParameterValues(commandParameters, parameterValues);
    
            return commandParameters;
        }
        return null;
    }
