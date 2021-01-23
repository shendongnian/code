    using Microsoft.Reporting.WebForms;
    
    public partial class ExportSoftware_Depb_Edi_Annex_B_Report : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Bind();
        }
        private void Bind()
        {
            DataSet sd = new DataSet();
            ExecuteProcedures ex = new ExecuteProcedures(1, CommonStrings.ConnectionString);
            ex.Parameters.Add("@intAnnexure_B_Id", SqlDbType.Int, Session["id"]);
            sd  = ex.LoadDatasetWithProcedure("ProcDEPBAnnexureBBind_Report");
            ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/ExportSoftware/Report/Depb_Edi_Annex_B.rdlc");
            ReportDataSource rds = new ReportDataSource();
            rds.Name = "Depb_Edi_Annex_B_DataTable1";
            rds.Value = sd.Tables[0];
            ReportViewer1.LocalReport.DataSources.Clear();
            ReportViewer1.LocalReport.DataSources.Add(rds);
            ReportViewer1.LocalReport.Refresh();
            ReportViewer1.Visible = true;
            ReportViewer1.Dispose();
        }
    
    }
