    public class ReadSession : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "application/json";
            context.Response.Write(new JavaScriptSerializer().Serialize(new
            {
                Key = context.Request["key"],
                Value = context.Session[context.Request["key"]]
            }));
        }
        public bool IsReusable 
        { 
            get { return false; } 
        }
    }
