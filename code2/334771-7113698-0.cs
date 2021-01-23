    DbCommand dbCommand = SqlDb.GetStoredProcCommand(uspCommand);
    foreach(String param in MyParameters)
    {
       DbParameter ProcessedFileName = dbCommand.CreateParameter();
       ProcessedFileName.DbType = DbType.String;
       ProcessedFileName.ParameterName = param;
       ProcessedFileName.Value = pstrProcessedFileName;
       dbCommand.Parameters.Add(ProcessedFileName);
    }
