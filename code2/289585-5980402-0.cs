    public void ProcessRequest(HttpContext context)
    {
    	if (context.Request.Params["file"] != null)
    	{	
                string filename = context.Request.Params["file"].ToString();
    		context.Response.Clear();
    		context.Response.ClearContent();
    		context.Response.ClearHeaders();
    		context.Response.Buffer = true;
    		
    		FileInfo fileInfo = new FileInfo(filename);
    
    		if (fileInfo.Exists)
    		{
    			context.Response.ContentType = /* your mime type */;
    			context.Response.AppendHeader("content-disposition", string.Format("attachment;filename={0}", fileInfo.Name));
    			context.Response.WriteFile(filename);
    		}
    		
    		context.Response.End();
    	}	
    }
