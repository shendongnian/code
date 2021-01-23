    public class RSSHandler : IHttpHandler
    {
        public void ProcessRequest (HttpContext context)
        {   
            context.Response.ContentType = "text/xml";
            context.Response.ContentEncoding = System.Text.Encoding.UTF8;
            string sXml = BuildXMLString(); 
            context.Response.Cache.SetExpires(DateTime.Now.AddSeconds(600));
            context.Response.Cache.SetCacheability(HttpCacheability.Public);
            context.Response.Write( sXml );
        }
        public bool IsReusable
        {
            get { return true; }
        }
    }
