     try
                {
                    ReportDocument rd = new ReportDocument();
                    //////////////////////
                    TableLogOnInfos crtableLogoninfos = new TableLogOnInfos();
                    TableLogOnInfo crtableLogoninfo = new TableLogOnInfo();
                    ConnectionInfo crConnectionInfo = new ConnectionInfo();
                    Tables CrTables;
                    rd.Load(System.AppDomain.CurrentDomain.BaseDirectory + "report\\" + this.report_name);
    
    
                    RegistryKey ConnectionKey = Registry.CurrentUser.CreateSubKey("SOFTWARE\\forosh");
                    string  server = (string)ConnectionKey.GetValue("ServerName");
                    crConnectionInfo.ServerName = server;
    
                    RegistryKey ConnectionKey2 = Registry.CurrentUser.CreateSubKey("SOFTWARE\\forosh");
                    string db = (string)ConnectionKey2.GetValue("DbName");
                    crConnectionInfo.DatabaseName = db;
                    crConnectionInfo.IntegratedSecurity = true;
    
                    CrTables = rd.Database.Tables;
                    foreach (CrystalDecisions.CrystalReports.Engine.Table CrTable in CrTables)
                    {
                        crtableLogoninfo = CrTable.LogOnInfo;
                        crtableLogoninfo.ConnectionInfo = crConnectionInfo;
                        CrTable.ApplyLogOnInfo(crtableLogoninfo);
                    }
    
                    crv.ViewerCore.ReportSource = rd;
                    crv.ViewerCore.RefreshReport();
                    //////////////////////////////
    
                    string path = System.AppDomain.CurrentDomain.BaseDirectory + "report\\" + this.report_name;
                    rd.Load(path);
                    rd.RecordSelectionFormula = this.GetFormula;
    
                    switch (report_name)
                    {
                        
                        case "full.rpt":
                            {
    
                                break;
                            }
                        case "formul.rpt":
                            {
    
                                break;
                            }
    
                    }
    
    
                    crv.ViewerCore.ReportSource = rd;
    
                }
                catch {
                    
                }
                }
    
     
