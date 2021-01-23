    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(webRequest.URL);
    request.UserAgent = webRequest.UserAgent;
    request.ContentType = webRequest.ContentType;
    request.Method = webRequest.Method;
        
    if (webRequest.BytesToWrite != null && webRequest.BytesToWrite.Length > 0) {
        Stream oStream = request.GetRequestStream();
        oStream.Write(webRequest.BytesToWrite, 0, webRequest.BytesToWrite.Length);
        oStream.Close();
    }
        
    // Send the request and get a response
    HttpWebResponse resp = (HttpWebResponse)request.GetResponse();
        
    // Read the response
    StreamReader sr = new StreamReader(resp.GetResponseStream());
        
    // return the response to the screen
    string returnedValue = sr.ReadToEnd();
        
    sr.Close();
    resp.Close();
        
    return returnedValue;
