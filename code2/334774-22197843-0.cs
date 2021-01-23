    public static class DbCommandExtensions
	{
		public static void AddParam(this DbCommand dbCommand, string fieldName, object fieldValue)
		{
			string fieldNameParameter = fieldName;
			DbParameter dbParameter = dbCommand.CreateParameter();
			dbParameter.ParameterName = fieldNameParameter;
			dbParameter.Value = fieldValue;
			dbCommand.Parameters.Add(dbParameter);
		}
	}
