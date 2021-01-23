    public class TestPdfHandler : IHttpHandler
    {
        #region IHttpHandler Membres
        public bool IsReusable
        {
            get { return true; }
        }
        public void ProcessRequest(HttpContext context)
        {
            string fileName = context.Request["pdfname"];
            
            byte[] buffer = null;
            buffer = File.ReadAllBytes("d:\\" + fileName +".pdf");
            context.Response.Clear();
            context.Response.ContentType = "application/pdf";
            context.Response.OutputStream.Write(buffer, 0, buffer.Length);
            context.Response.End();
        }
        #endregion
    }
