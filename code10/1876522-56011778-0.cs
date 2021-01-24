    static public XmlaResultCollection RunWithCaptureLog(Server server, string dbName)
    {
        if ((svr != null) && (svr.Connected))
        {
            svr.CaptureXml = true;
            #region Actions to be captured to an XMLA file  
            foreach (Table table in server.Databases.GetByName(dbName).Model.Tables)
            {
                foreach (Partition partition in table.Partitions){
                    partition.RequestRefresh(Microsoft.AnalysisServices.Tabular.RefreshType.Full);
                }
            }
            #endregion
            svr.CaptureXml = false;
            //public Microsoft.AnalysisServices.XmlaResultCollection ExecuteCaptureLog (bool transactional, bool parallel, bool processAffected)
            return svr.ExecuteCaptureLog(true, true, true);
        }
    }
