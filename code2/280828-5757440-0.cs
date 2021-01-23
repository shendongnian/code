    public class SpellCheckerHttpHandler : IHttpHandler
    {
        public bool IsReusable { get { return true; } }
    
        public void ProcessRequest(HttpContext context)
        {
            //Write out the JSON you want to return.
            string json = GetTheJson();
    
            context.Response.ContentType = "application/json";
            context.Response.Write(json);
        }
    }
