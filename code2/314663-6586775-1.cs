    /// <summary>
    /// Executes a stored procedure with no return.
    /// </summary>
    /// <returns>The number of records affected by stored proc.</returns>
    public static int ExecuteStoredProc(string storedProcName, params SqlParameter[] parameters)
    {        
        StringBuilder callDefinition = new StringBuilder();
        callDefinition.Append(string.Format("ExecuteStoredProc: {0} (", storedProcName));
        for (int i = 0; i < parameters.Count(); i++)
        {
            callDefinition.Append(string.Format("{0}={1}", parameters[i].ParameterName, parameters[i].Value));
            if (i < parameters.Count - 1)
            {
                callDefinition.Append(",");
            }
        }
        callDefinition.Append(")";
        log.Debug(callDefinition.ToString());
        using (var ctx = ConnectionManager<SqlConnection>.GetManager(ConnectionProfile.ConnectionName))
        {
            using (SqlCommand command = new SqlCommand(storedProcName, ctx.Connection))
            {
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandTimeout = 1000;
                foreach (SqlParameter parameter in parameters)
                {
                    command.Parameters.Add(parameter);
                    //log your param here
                }
                return command.ExecuteNonQuery();
            }
        }
    }
    /// <summary>
    /// Executes a query and returns a dataset
    /// </summary>
    public static DataSet ExecuteQueryReturnDataSet(string query, params SqlParameter[] parameters)
    {
        try
        {
            //implement the parameter logging here as in the above code sample as well
            log.Debug("Executing ExecuteQueryReturnDataSet() calling query " + query);
            using (var ctx = ConnectionManager<SqlConnection>.GetManager(ConnectionProfile.ConnectionName))
            {
                using (SqlCommand command = new SqlCommand(query, ctx.Connection))
                {
                    command.CommandType = System.Data.CommandType.Text;
                    command.CommandTimeout = 1000;
                    foreach (SqlParameter parameter in parameters)
                    {
                        command.Parameters.Add(parameter);
                    }
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        DataSet dataSet = new DataSet();
                        adapter.Fill(dataSet);
                        return dataSet;
                    }
                }
            }
        }
        catch (Exception ex)
        {
            log.Error(ex);
            throw;
        }
    }
