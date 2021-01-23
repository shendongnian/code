    string requestBody = string.Format("registration_id={0}&collapse_key{1}&data.key=value",
                                        HttpUtility.UrlEncode(registrationId), "collapse");
    string responseBody = null;
    WebHeaderCollection requestHeaders = new WebHeaderCollection();
    WebHeaderCollection responseHeaders = null;
    requestHeaders.Add(HttpRequestHeader.Authorization, string.Format("GoogleLogin auth={0}", authToken));
            
    httpClient.DoPostWithHeaders(c2dmPushUrl,
                      requestBody,
                      "application/x-www-form-urlencoded",
                      out responseBody,
                      out responseHeaders,
                      requestHeaders);
    public bool DoPostWithHeaders(string url, 
                                  string requestBody, 
                                  string contextType,
                              out string responseBody,
                              out WebHeaderCollection responseHeaders,
                                  WebHeaderCollection requestHeaders = null)
    {
        HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
    
        // FIRST SET REQUEST HEADERS
    
        httpWebRequest.Headers = requestHeaders;
        httpWebRequest.Method = "POST";
    
        // THEN SET CONTENT TYPE - THE ORDER IS IMPORTANT
    
        httpWebRequest.ContentType = contextType; 
        ASCIIEncoding encoding = new ASCIIEncoding();
        byte[] data = encoding.GetBytes(requestBody);
        httpWebRequest.ContentLength = data.Length;
                    
        stream = httpWebRequest.GetRequestStream();
        stream.Write(data, 0, data.Length);
    
        ....
        ....
        ....
    }
