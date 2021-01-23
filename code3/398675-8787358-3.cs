       public void ProcessRequest(HttpContext context)
    {
    	HttpPostedFile fileupload = context.Request.Files["file"];
    
    	// process your fileupload...
    	
    	context.Response.ContentType = "text/plain";
    	context.Response.Write("Ok");
    }
