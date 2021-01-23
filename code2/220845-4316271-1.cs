    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
    
        }
    
        public void GetCSV(object sender, EventArgs e)
        {
            DataView dv = (DataView)SqlDataSourceLocal.Select(DataSourceSelectArguments.Empty);
            var dt = dv.ToTable();
    
            var csv = dt.ToCSV();
    
            WriteToOutput(csv, "export.csv", "text/csv");
        }
    
        private void WriteToOutput(String csv, String fileName, String mimeType)
        {
            Response.Clear();
            Response.ContentType = mimeType;
            Response.AddHeader("Content-Disposition", String.Format("attachment;filename={0}", fileName));
            Response.Write(csv);
            Response.End();
        }
    }
