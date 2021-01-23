    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }
        protected void ReportDateControl_UpdateReport(object sender, EventArgs e)
        {
            Controls.ReportDateControl control = (Controls.ReportDateControl)sender;
            string fromDate = control.FromDate;
            string toDate = control.ToDate;
        }
    }
