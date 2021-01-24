    public FrmReport()
    {
    	InitializeComponent();
    	rpDoc = new ReportDocument();
    	crvReportes.AllowedExportFormats = (int)(ViewerExportFormats.ExcelFormat | ViewerExportFormats.PdfFormat| ViewerExportFormats.WordFormat);
    }
    private void LoadReport()
    {
    	try
    	{
    		rpDoc.Load((Application.StartupPath + "\\rpExclu.rpt").Replace("\\bin\\Debug", ""));
    		rpDoc.SetParameterValue("@IDA", this.ida);
    		rpDoc.SetDatabaseLogon(this.us, this.pass);
    		crvReportes.ReportSource = rpDoc;
    		crvReportes.Refresh();
    	}
    	catch (Exception ex)
    	{
    		crvReportes.Refresh();
    		XtraMessageBox.Show("" + ex.Message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
    	}
    }
    private void FrmReporteBienes_FormClosing(object sender, FormClosingEventArgs e)
    {
    	if (rpDoc.IsLoaded)
    	{
    		rpDoc.Dispose();
    		rpDoc.Close();
    	}
    }
