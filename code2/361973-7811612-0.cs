    namespace svgzHandler 
    {
        using System; 
        using System.Web; 
        public class svgzHandler : IHttpHandler
        {
            public bool IsReusable { get { return true; } }
    
            public void ProcessRequest(HttpContext context)
            {
                HttpResponse r = context.Response;
                r.ContentType = "image/svg+xml";
                r.AppendHeader("Content-Encoding", "gzip");
                r.WriteFile(context.Request.PhysicalPath);
            }
        } 
    }
