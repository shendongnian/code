    if (!IsPostBack)
    {
       // your code inside 
   
        var connectionInfo = new ConnectionInfo();
        connectionInfo.ServerName = "server_name";
        connectionInfo.DatabaseName = "database_name";
        connectionInfo.UserID = "database_user_name";
        connectionInfo.Password = "database_password";
        connectionInfo.Type = ConnectionInfoType.SQL;
        connectionInfo.IntegratedSecurity = false;
    
    for (int i = 0; i < CrystalReportViewer1.LogOnInfo.Count; i++)
    {
        CrystalReportViewer1.LogOnInfo[i].ConnectionInfo = connectionInfo;
    }
    }
