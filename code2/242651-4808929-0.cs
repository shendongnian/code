    WebRequest request = WebRequest.Create(url);
    request.Timeout = 5000;
    
    using (WebResponse response = request.GetResponse())
    using (XmlReader reader = XmlReader.Create(response.GetResponseStream()))
    {
        // Blah blah...
    }
