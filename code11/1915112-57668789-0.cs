    public DataTable CallStoredProcedure(System.String procedureName, Dictionary<string, object> parameters)
            {
                var cmd = CreateStoredProcCallCommand(procedureName, true);
                for (int i = 0; i < parameters.Count; i++)
                {
                    var param = parameters.ElementAt(i);
                    if (param.Value.GetType() == typeof(DataTable))
                        AddTableValuedParameter(cmd, "@" + param.Key, 0, ParameterDirection.Input, param.Value);
                    else
                        AddParameter(cmd, "@" + param.Key, 2147483647, ParameterDirection.Input, param.Value);
                }
    
                var toReturn = new DataTable();
                CreateAndSetupAdapter(cmd).Fill(toReturn);
                return toReturn;
            }
    private DbCommand CreateStoredProcCallCommand(string storedProcedureToCall, bool openConnection)
    		{
    			var cmd = _factoryToUse.CreateCommand();
    			cmd.CommandType = CommandType.StoredProcedure;
    			cmd.CommandText = storedProcedureToCall;
    			return SetupCommand(cmd, openConnection);
    		}
	private DbDataAdapter CreateAndSetupAdapter(DbCommand selectCommand)
	{
		var adapter = _factoryToUse.CreateDataAdapter();
		adapter.SelectCommand = selectCommand;
		return adapter;
	}
     private static void AddTableValuedParameter(DbCommand cmd, string parameterName, int length, ParameterDirection direction, object value)
            {
                SqlParameter param = new SqlParameter();
                param.ParameterName = parameterName;
                param.SqlDbType = SqlDbType.Structured;
                param.Size = length;
                param.Value = value;
                param.Direction = direction;
                cmd.Parameters.Add(param);
            }
    private static void AddParameter(DbCommand cmd, string parameterName, int length, ParameterDirection direction, object value)
    		{
    			var dummyParam = new EntityParameter() { Value = value };
    			var parameter = cmd.CreateParameter();
    			parameter.ParameterName = parameterName;
    			parameter.Direction = direction;
    			parameter.Size = length;
    			parameter.Value = value;
    			parameter.DbType = dummyParam.DbType;
    			cmd.Parameters.Add(parameter);
    		}
    		
