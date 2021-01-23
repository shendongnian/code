    public partial class PdfReport : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var pdfDocumentName = Request.Params["filename"].ToString() + ".pdf";
            var myReport = "Razor Syntax Quick Reference.pdf";
            var FileName = Path.Combine(Path.Combine(Server.MapPath("~"), "Temp"), myReport);
            Response.Clear();
            Response.ClearHeaders();
            Response.ClearContent();
            Response.ContentType = "application/pdf";
            Response.AddHeader("Content-Type", "application/pdf");
            Response.AddHeader("content-disposition", "attachment; filename=" + pdfDocumentName);
            Response.TransmitFile(FileName);
            Response.End();
        }
    }
