    HttpResponseMessage response = await ExecutionContext.HttpClient.GetAsync(odataQuery);
    // Different checks in real code but here a simple one 
	if (response.StatusCode.Equals(HttpStatusCode.ServiceUnavailable) || response.StatusCode.Equals(HttpStatusCode.RequestTimeout) || response.StatusCode.Equals(HttpStatusCode.NotFound)
	{
		if (response.Content.ToString().Contains("error") ||
			response.Content.ToString().Contains("Resource not found")
			)
		{
			// Log error Here 
			throw new TransientFaultException();
		}
			
	}
