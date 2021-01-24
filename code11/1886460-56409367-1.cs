         log.Info("process table " + tables.getTables.ElementAt(i).Name);
         Table t = m.Tables[tables.getTables.ElementAt(i).Name];
         t.RequestRefresh(Microsoft.AnalysisServices.Tabular.RefreshType.Full);
                    
    }
    m.SaveChanges();
    conn.Disconnect();
