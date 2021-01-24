    try
    {
      using (SqlCommand auditCommand = new SqlCommand(
                                             auditStoredProc,
                                             localConnection,
                                             tran))
      {
         auditCommand.CommandType = CommandType.StoredProcedure;
         auditCommand.CommandTimeout = sqlCommandTimeoutFallbackValue;
         var userNameParam = auditCommand.CreateParameter();
         userNameParam.ParameterName = "@username";
         userNameParam.SqlDbType = SqlDbType.NVarChar;
         userNameParam.Value = "JobQueueService";
         auditCommand.Parameters.Add(userNameParam);
         auditCommand.ExecuteNonQuery();
      }
    }
    catch (Exception e)
    {
       Logger.Error("Error executing audit storedprocedure" + e.ToString());                                            
    }
