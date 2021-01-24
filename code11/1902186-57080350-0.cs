    public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
    {
    	HttpContext.Current.Response.Clear();
    	HttpResponseMessage response = null;
    
    	using (var stream = new File.OpenRead(path))
    	{
    		response = new HttpResponseMessage { Content = new StreamContent(stream)};
    		
    		response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/x-zip-compressed");
    	
    		response.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment")
    		{
    			FileName = Filename
    		}; 
    	}	
    	
    	return Task.FromResult(response);
    }
