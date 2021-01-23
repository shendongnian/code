        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
					DataSet dataset  =  GetPopulatedDatasetFromDB()    // Populate your dataset here by calling the stored proc.
			
                    ReportViewer1.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Local;
                    ReportViewer1.LocalReport.ReportPath = Server.MapPath("/Reports/MyNewReport.rdlc");
                    ReportViewer1.LocalReport.DataSources.Clear();
                    ReportViewer1.LocalReport.DataSources.Add(
                        new Microsoft.Reporting.WebForms.ReportDataSource("DataSet1", dataset.Tables[0]));
                    ReportViewer1.LocalReport.Refresh();
			}
		}
