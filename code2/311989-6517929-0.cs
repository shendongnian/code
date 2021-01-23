    public class Texts : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/javascript";
            context.Response.Write("var texts = { Some: 'some text here' }");
        }
        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
