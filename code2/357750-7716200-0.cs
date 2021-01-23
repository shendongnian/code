    public static void ConfigureLogonInfo(ReportDocument _report, ConnectionInfo _conn)
        {
            _report.DataSourceConnections.Clear();
            foreach(Table tbl in _report.Database.Tables)
            {
                tbl.LogOnInfo.ConnectionInfo = _conn;
            }
            for(int i = 0; i < _report.Subreports.Count; i++)
            {
                var sub = _report.Subreports[i];
                sub.DataSourceConnections.Clear();                
                foreach(Table tbl in sub.Database.Tables)
                {
                    tbl.LogOnInfo.ConnectionInfo = _conn;
                }
            }
        }
