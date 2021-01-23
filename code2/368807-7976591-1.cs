    public class MyHandler :
        IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            var fileName = Request[@"fn"];
    	    var filePath = Path.Combine(@"C:\My\Fixed\File\Path", fileName );
    
    	    Response.ContentType = @"application/pdf";
    
    	    Response.AddHeader(
    	        @"Content-Disposition", 
    	        @"attachment; filename=" + Path.GetFileName(filePath));
    	    Response.AddHeader(
    	        @"Content-Length",
    	        new FileInfo(filePath).Length );
    	    Response.WriteFile(filePath);
    	    Response.End();
        }
    
        public bool IsReusable
        {
            get { return false; }
        }
    }
