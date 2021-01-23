    public class FileUploadHandler : IHttpHandler 
    {
        public void ProcessRequest (HttpContext context) 
    	{
    		HttpResponse response = context.Response;
    		
    		foreach (string file in context.Request.Files)  
    		{  
    		   HttpPostedFile hpf = context.Request.Files[file] as HttpPostedFile;  
    		   if (hpf.ContentLength == 0)  
    			  continue; 
    		   //DO SOMETHING WITH FILE.
    		}
    		
    		//RETURN ANY RESPONSE USING response OBJECT
        }
    
        public bool IsReusable 
    	{
    		get
    		{
    			return false;
    		}
    	}
    }
