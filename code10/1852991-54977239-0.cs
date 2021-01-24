    if (request?.ContentLength != null)
    {
    	request.EnableRewind();
    
    	request.Body.Seek(0, SeekOrigin.Begin);
    
    	using (var reader = new StreamReader(request.Body, Encoding.UTF8))
    	{
    		body = reader.ReadToEnd();
    		
    		//Do your thing with the body content
    	}
    
    }
