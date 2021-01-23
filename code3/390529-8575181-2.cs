    string url = "http://sms80.com";
    HttpWebRequest http = (HttpWebRequest)WebRequest.Create(url);
    http.CookieContainer = _cookieJar;
    http.Connection = "Keep-alive";
    http.Method = "POST";
    http.ContentType = "application/x-www-form-urlencoded";
    string postData="username=" + username + "&password=" + password;
    byte[] dataBytes = UTF8Encoding.UTF8.GetBytes(postData);
    http.ContentLength = dataBytes.Length;
    Stream postStream = http.GetRequestStream();
    postStream.Write(dataBytes, 0, dataBytes.Length);
    postStream.Close();
    // see if we're logged in
    HttpWebResponse httpResponse = (HttpWebResponse)http.GetResponse();
    // continue (read the response etc.)
