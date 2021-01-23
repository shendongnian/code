    var rd = new CrystalReport1();
                ConnectionInfo connectionInfo = new ConnectionInfo();
                connectionInfo.DatabaseName = @"d:\testing\test2.mdb";
                connectionInfo.UserID = "admin";
                foreach (Table table in rd.Database.Tables)
                {
                    TableLogOnInfo logonInfo = table.LogOnInfo;
                    logonInfo.ConnectionInfo = connectionInfo;
                    table.ApplyLogOnInfo(logonInfo);                
                }
                crystalReportViewer1.ReportSource = rd;
