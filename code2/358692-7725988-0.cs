    using System.IO;
    using System.Web;
    
    public class Docs : IHttpHandler 
    {
        public void ProcessRequest (HttpContext context) 
        {
            context.Response.ContentType = "application/vnd.openxmlformats-officedocument.wordprocessingml.document";
            using (var streamReader = new StreamReader("fileSourceForDemonstration.docx"))
            {
                streamReader.BaseStream.CopyTo(context.Response.OutputStream);
            }
        }
     
        public bool IsReusable 
        {
            get { return false; }
        }
    }
