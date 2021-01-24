    DoRequest("PeculiarApi", response =>
    {
    	if ((response.StatusCode == HttpStatusCode.Success) || 
    		(response.StatusCode == HttpStatusCode.Conflict))
    	{
    		if (response.Headers.TryGet(Headers.ContentType, out var contentType) && 
    			(contentType == ContentType.ApplicationJson))
    		{
    			return JsonConvert.Deserialize<TModel>(response.Content);
    		}
    		throw new Exception("No content type");
    	}
    	if (response.StatusCode == (HttpStatusCode)599) // Yes, that's what they return
    	{
    		return XmlConvert.Deserialize<T599Model>(response.Content).Errors[2];
    	}
    	...
    }
