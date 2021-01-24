    string url = "https://api.xxxxx.com/v1/login/";
    
    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
    request.Method = "POST";
    request.Headers.Add("API-key", "your-api-key-if-any");
    request.UserAgent = "Mozilla/5.0 (compatible; MSIE 9.0; Windows NT 7.1; Trident/5.0)";
    request.Accept = "/";
    request.UseDefaultCredentials = true;
    request.Proxy.Credentials = System.Net.CredentialCache.DefaultCredentials;
    
    string postData = "This is a test that posts this string to a Web server.";
    byte[] byteArray = Encoding.UTF8.GetBytes(postData);
    
    request.ContentType = "application/x-www-form-urlencoded";
    // Set the ContentLength property of the WebRequest.  
    request.ContentLength = byteArray.Length;
    
    // Get the request stream.  
    Stream dataStream = request.GetRequestStream();
    // Write the data to the request stream.  
    dataStream.Write(byteArray, 0, byteArray.Length);
    // Close the Stream object.  
    dataStream.Close();
    
    
    HttpWebResponse resp = request.GetResponse() as HttpWebResponse;
    using (var streamReader = new StreamReader(resp.GetResponseStream()))
    {
        var result = streamReader.ReadToEnd();
    }
