    public class Handler1 : IHttpHandler
    {
    
        public void ProcessRequest(HttpContext context)
        {
            var fileName = context.Request["fileName"];
            var fullPath = Path.Combine("SomeLocalPath", fileName);
    
            //Do something to validate the file
            if (File.Exists(fullPath))
            {
                context.Response.Write("valid");
            }
            else
            {
                context.Response.Write("invalid");
            }
    
        }
    
        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
