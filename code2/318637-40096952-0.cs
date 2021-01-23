            CloseReport();
        }
        /// <summary>
        /// This method is used to clear the temporary files created by Crystal Reports
        /// </summary>
        protected void CloseReport()
        {
            try
            {
                if(cryRpt != null)
                {
                    Sections objSections = cryRpt.ReportDefinition.Sections;
                    foreach (Section objSection in objSections)
                    {
                        ReportObjects objReports = objSection.ReportObjects;
                        foreach(ReportObject rptObj in objReports)
                        {
                            if(rptObj.Kind.Equals(CrystalDecisions.Shared.ReportObjectKind.SubreportObject))
                            {
                                SubreportObject subreportObject = (SubreportObject)rptObj;
                                ReportDocument subReportDocument = subreportObject.OpenSubreport(subreportObject.SubreportName);
                                subReportDocument.Close();
                            }
                        }
                    }
                    cryRpt.Close();
                    cryRpt.Dispose();
                }
                if(crReportViewer != null)
                {
                    crReportViewer.ReportSource = null;
                    crReportViewer.Dispose();
                }
            }
            catch
            {
            }
        }
