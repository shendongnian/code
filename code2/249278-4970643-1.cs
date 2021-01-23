    HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://a/rest/uri");
    request.Method = "POST";
    request.Headers.Add("Authorization: OAuth " + accessToken);
    string postData = string.Format("param1=something&param2=something_else");
    byte[] data = Encoding.UTF8.GetBytes(postData);
    
    request.ContentType = "application/x-www-form-urlencoded";
    request.Accept = "application/json";
    request.ContentLength = data.Length;
    
    using (Stream requestStream = request.GetRequestStream())
    {
        requestStream.Write(data, 0, data.Length);
    }
    
    try
    {
        using(WebResponse response = request.GetResponse())
        {
            // Do something with response
        }
    }
    catch (WebException ex)
    {
        // Handle error
    }
