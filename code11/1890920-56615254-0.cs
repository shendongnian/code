    //Create an HTTP client object
    Windows.Web.Http.HttpClient httpClient = new Windows.Web.Http.HttpClient();
    
    //Add a user-agent header to the GET request. 
    var headers = httpClient.DefaultRequestHeaders;
    
    //The safe way to add a header value is to use the TryParseAdd method and verify the return value is true,
    //especially if the header value is coming from user input.
    string header = "ie";
    if (!headers.UserAgent.TryParseAdd(header))
    {
        throw new Exception("Invalid header value: " + header);
    }
    
    header = "Mozilla/5.0 (compatible; MSIE 10.0; Windows NT 6.2; WOW64; Trident/6.0)";
    if (!headers.UserAgent.TryParseAdd(header))
    {
        throw new Exception("Invalid header value: " + header);
    }
    
    Uri requestUri = new Uri("http://www.contoso.com");
    
    //Send the GET request asynchronously and retrieve the response as a string.
    Windows.Web.Http.HttpResponseMessage httpResponse = new Windows.Web.Http.HttpResponseMessage();
    string httpResponseBody = "";
    
    try
    {
        //Send the GET request
        httpResponse = await httpClient.GetAsync(requestUri);
        httpResponse.EnsureSuccessStatusCode();
        httpResponseBody = await httpResponse.Content.ReadAsStringAsync();
    }
    catch (Exception ex)
    {
        httpResponseBody = "Error: " + ex.HResult.ToString("X") + " Message: " + ex.Message;
    }
