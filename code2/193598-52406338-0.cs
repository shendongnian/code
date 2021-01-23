    public static HttpStatusCode GetUrlStatus(string url, string userAgent)
    {
    	HttpStatusCode result = default(HttpStatusCode);
    
    	HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
    	request.UserAgent = userAgent;
    	request.Method = "HEAD";
    
    	try
    	{
    		using (var response = request.GetResponse() as HttpWebResponse)
    		{
    			if (response != null)
    			{
    				result = response.StatusCode;
    				response.Close();
    			}
    		}
    	}
    	catch (WebException we)
    	{
    		result = ((HttpWebResponse)we.Response).StatusCode;
    	}
    
    	return result;
    }
    
    
    [Test]
    public void PageNotFoundShouldReturn404()
    {
    	//Arrange
    	HttpStatusCode expected = HttpStatusCode.NotFound;
    	string userAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/68.0.3440.106 Safari/537.36";
    
    	//Act
    	HttpStatusCode result = WebHelper.GetUrlStatus("http://www.kellermansoftware.com/SomePageThatDoesNotExist", userAgent);
    
    	//Assert
    	Assert.AreEqual(expected, result);
    }	
	
