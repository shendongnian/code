    public class MyHandler :
        IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            var fileName = Request[@"fn"];
    	    var filePath = Path.Combine(@"C:\My\Fixed\File\Path", fileName );
    
    	    Response.ContentType = @"application/pdf";
    
    	    Response.WriteFile(filePath);
    	    Response.End();
        }
    
        public bool IsReusable
        {
            get { return false; }
        }
    }
