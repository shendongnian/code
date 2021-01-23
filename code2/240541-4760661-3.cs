    var arr = new[]
    {
        "http://example.com/image.jpg",
        "http://example.com/image2.jpg"
        ...
    };
    
    myImg.ImageUrl = arr.FirstOrDefault(i => CheckExistence(i));
    
    static bool CheckUrlExistence(string url)
    {
    	try
    	{
    		var request = (HttpWebRequest)WebRequest.Create(url);
    		request.Credentials = CredentialCache.DefaultCredentials;
    		request.Method = "HEAD";
    		var response = (HttpWebResponse)request.GetResponse();
    		return response.StatusCode == HttpStatusCode.OK;
    	}
    	catch (Exception ex)
    	{
    		var code = ((HttpWebResponse)((WebException)ex).Response).StatusCode; // NotFound, etc
    		return false;
    	}
