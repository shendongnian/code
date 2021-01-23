    const string RemoteUrl = "http://www.servicestack.net/ServiceStack.Hello/servicestack/hello";
    
    var httpReq = (HttpWebRequest)WebRequest.Create(RemoteUrl);
    httpReq.Method = "POST";
    httpReq.ContentType = httpReq.Accept = "application/json";
    
    using (var stream = httpReq.GetRequestStream())
    using (var sw = new StreamWriter(stream))
    {
        sw.Write("{\"Name\":\"World!\"}");
    }
    
    using (var response = httpReq.GetResponse())
    using (var stream = response.GetResponseStream())
    using (var reader = new StreamReader(stream))
    {
        Assert.That(reader.ReadToEnd(), Is.EqualTo("{\"Result\":\"Hello, World!\"}"));
    }
