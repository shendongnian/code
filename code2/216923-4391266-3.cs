    public partial class Export : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                exportToCSV();
            }
        }
        private void exportToCSV()
        {
            Context.Response.Clear();
            Context.Response.ClearContent();
            Context.Response.ClearHeaders();
            Context.Response.AddHeader("Content-Disposition", "attachment;filename=ShortageReport.csv");
            Context.Response.ContentType = "text/csv";
            char[] separator = Environment.NewLine.ToCharArray();
            string csv = ((StringBuilder)Session["ExportCSV"]).ToString();
            foreach (string line in csv.Split(separator))
            {
                Context.Response.Write(line);
            }
            Context.Response.Flush();
            Context.Response.End();
        }
    }
