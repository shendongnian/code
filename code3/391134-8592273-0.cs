	public static int ExecuteNonQuery(string sql, params object[] parameters)
    {
        int result = 0;
	        try
	        {
		        var command = new OdbcCommand();
                using (OdbcConnection connection = new OdbcConnection(GetConnectionString() /*irrelevant*/))
                {
                   connection.Open();
                   Prepare(command, connection, null, CommandType.Text, sql,
                           parameters == null ?
                                               new List<OdbcParameter>().ToArray() :
                                               parameters.Select(p => p is OdbcParameter ? (OdbcParameter)p : new OdbcParameter(string.Empty, p)).ToArray());
                
                   result = command.ExecuteNonQuery();
                }
	        }
	        catch (OdbcException ex)
	        {
		        // Logging here
		        throw;
	        }
        return result;
    }
