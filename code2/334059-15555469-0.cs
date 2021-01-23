    TableLogOnInfos crtableLogoninfos = new TableLogOnInfos()
    TableLogOnInfo crtableLogoninfo = new TableLogOnInfo();
    var connectionInfo = new ConnectionInfo();
    connectionInfo.ServerName = "157.182.x.xxx";
    connectionInfo.DatabaseName = "xxxx";
    connectionInfo.Password = "xxxx";
    connectionInfo.UserID = "xxxx";
    connectionInfo.Type = ConnectionInfoType.SQL;
    for (int i = 0; i < CrystalReportViewer1.LogOnInfo.Count; i++)
      {
          CrystalReportViewer1.LogOnInfo[i].ConnectionInfo = connectionInfo;
      }
