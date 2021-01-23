    public class Handler1 : IHttpHandler, System.Web.SessionState.IRequiresSessionState 
    {
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            context.Response.Write("Hello World");
            context.Session["loggedIn"] = true;
        }
        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
