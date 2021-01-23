    TableLogOnInfo logOnInfo;
    foreach (CrystalDecisions.CrystalReports.Engine.Table tbCurrent in report.Database.Tables)
    {
      logOnInfo= tbCurrent.LogOnInfo;
      logOnInfo.ConnectionInfo.DatabaseName = "MyDatabaseName";
      logOnInfo.ConnectionInfo.UserID = "UserId";
      logOnInfo.ConnectionInfo.Password = "secretpassword";
      logOnInfo.ConnectionInfo.ServerName = "SQLServer";
      logOnInfo.ConnectionInfo.Type = ConnectionInfoType.SQL;
      tbCurrent.ApplyLogOnInfo(logOnInfo);
    }
