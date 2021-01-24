    Tables tblsReport = crReport.Database.Tables;
    for(int i=0; i<tblsreport.count;i++)>
    {
       Table tblReport = tblsReport[i];
       TableLogOnInfo tliTable = tblReport.LogOnInfo;
       tliTable.ConnectionInfo = crConn;
       tblReport.ApplyLogOnInfo(tliTable);
    }
