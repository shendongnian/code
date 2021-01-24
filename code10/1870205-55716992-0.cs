    Sections crSections; 
    ReportDocument crReportDocument, crSubreportDocument; 
    SubreportObject crSubreportObject;
    ReportObjects crReportObjects; 
    ConnectionInfo crConnectionInfo; 
    Database crDatabase; 
    Tables crTables; 
    TableLogOnInfo crTableLogOnInfo; 
    crReportDocument = new ReportDocument();
    crReportDocument.Load("c:\\reports\\Homes.rpt",CrystalDecisions.Shared.
    OpenReportMethod.OpenReportByTempCopy); 
    crDatabase = crReportDocument.Database; 
    crTables = crDatabase.Tables; 
    crConnectionInfo = new ConnectionInfo(); 
    crConnectionInfo.ServerName = "DSNName Or Server Name"; 
    crConnectionInfo.DatabaseName = "HopeAndHome";
    crConnectionInfo.UserID = "sa"; 
    crConnectionInfo.Password = "password"; 
                foreach (Section crSection in crSections)
            {
                crReportObjects = crSection.ReportObjects;
                //loop through all the report objects in there to find all subreports 
                foreach (ReportObject crReportObject in crReportObjects)
                {
                    if (crReportObject.Kind == ReportObjectKind.SubreportObject)
                    {
                        crSubreportObject = (SubreportObject)crReportObject;
                        //open the subreport object and logon as for the general report 
                        crSubreportDocument = crSubreportObject.OpenSubreport(crSubreportObject.SubreportName);
                        crDatabase = crSubreportDocument.Database;
                        crTables = crDatabase.Tables;
                        foreach (CrystalDecisions.CrystalReports.Engine.Table aTable in crTables)
                        {
                            crTableLogOnInfo = aTable.LogOnInfo;
                            crTableLogOnInfo.ConnectionInfo = crConnectionInfo;
                            aTable.ApplyLogOnInfo(crTableLogOnInfo);
                        }
                    }
                }
            }
}
