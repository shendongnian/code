    public class IISHandler1 : IHttpHandler
        {
            public bool IsReusable
            {
                get { return true; }
            }
    
            public void ProcessRequest(HttpContext context)
            {
                string url = content.Request.Url.ToString();
                string newUrl = Translate(url);
                context.Response.ResponseCode = 301;
                context.Response.Redirect(newUrl);
            }
    
        }
