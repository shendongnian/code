    // Clear existing connection info first
    rptDoc.DataSourceConnections.Clear();
    
    foreach (CrystalDecisions.CrystalReports.Engine.Table oTable in rptDoc.Database.Tables)
    {
      var oTableLogonInfo = oTable.LogonInfo;
      oTableLogonInfo.ConnectionInfo = oConnectionInfo;
      oTable.ApplyLogOnInfo(oTableLogonInfo);
      bool b = oTable.TestConnectivity();
      if (!b)
      {
          invokeErrorLogger(sparams, env);
      }
    }  
