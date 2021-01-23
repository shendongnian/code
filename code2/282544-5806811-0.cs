    public class YourHandler : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            Response.Clear();
            Response.ContentType = "text/xml";
            Response.AppendHeader("Content-Disposition", String.Format("attachment;filename={0}", XML_FileName));
            Response.TransmitFile(Server.MapPath("MyFile.xml"));
            Response.End();
        }
    
        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
