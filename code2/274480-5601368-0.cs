	public StreamReader GetWebReader(string uri)
	{
		var webRequest = WebRequest.Create(uri);
		var webResponse = webRequest.GetResponse();
		var responseStream = webResponse.GetResponseStream();
		return new StreamReader(responseStream);
	}
	
