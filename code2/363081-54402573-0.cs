    DbCommand command = CreateCommand(ct.SourceServer, ct.SourceInstance, ct.SourceDatabase);
    command.CommandType = CommandType.StoredProcedure;
    command.CommandText = "[ETL].[pGenerateScriptToCreateIndex]";
    
    DbParameter param = command.CreateParameter();
    param.ParameterName = "@IndexTypeID";
    param.DbType = DbType.Int16;
    param.Value = 1;
    command.Parameters.Add(param);
    
    param = command.CreateParameter(); --This is the line I was missing
    param.ParameterName = "@SchemaName";
    param.DbType = DbType.String;
    param.Value = ct.SourceSchema;
    command.Parameters.Add(param);
    
    param = command.CreateParameter(); --This is the line I was missing
    param.ParameterName = "@TableName";
    param.DbType = DbType.String;
    param.Value = ct.SourceDataObjectName;
    command.Parameters.Add(param);
        
    dt = ExecuteSelectCommand(command);
