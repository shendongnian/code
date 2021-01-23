    WebClient client = new WebClient()    
    client.Headers.Add(HttpRequestHeader.UserAgent, "");
    var stream = client.OpenRead("http://www.yahoo.com");
    StreamReader sr = new StreamReader(stream);
    s = sr.ReadToEnd();
