    namespace MyProject
    {
        public class ZipHandler: IHttpHandler
        {
            public bool IsReusable { get { return true; } }
            public void ProcessRequest(HttpContext context) { ... }
        }
    }
