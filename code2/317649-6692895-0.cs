    ableLogOnInfos crtableLogoninfos = new TableLogOnInfos();
                    TableLogOnInfo crtableLogoninfo = new TableLogOnInfo();
                    ConnectionInfo CInfo = new ConnectionInfo();
                    //GET THE SERVER INFORMATION
                    DataTable DT = b.GetServerInfo();
                    CInfo.ServerName = DT.Rows[0][1].ToString();
                    CInfo.DatabaseName = DT.Rows[0][2].ToString();
                    CInfo.UserID = DT.Rows[0][3].ToString();
                    CInfo.Password = DT.Rows[0][4].ToString();
                    Tables CrTables = cr.Database.Tables;
                    foreach (CrystalDecisions.CrystalReports.Engine.Table CrTable in CrTables)
                    {
                        crtableLogoninfo = CrTable.LogOnInfo;
                        crtableLogoninfo.ConnectionInfo = CInfo;
                        CrTable.ApplyLogOnInfo(crtableLogoninfo);
                    }
    
    
                    frmReportViewer ff = new frmReportViewer();
                    ff.crViewer.LogOnInfo = crtableLogoninfos;
                    ff.crViewer.ReportSource = cr;
