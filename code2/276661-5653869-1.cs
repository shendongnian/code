    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(new Uri(myUrl));
    request.Method = "POST";
    request.ContentType = "application/xml";
    request.Accept = "application/xml";
    
    XElement redmineRequestXML =
    	new XElement("issue",
    	new XElement("project_id", 17)
    );
    
    byte[] bytes = Encoding.UTF8.GetBytes(redmineRequestXML.ToString());
    
    request.ContentLength = bytes.Length;
    
    using (Stream putStream = request.GetRequestStream())
    {
    	putStream.Write(bytes, 0, bytes.Length);
    }
    
    // Log the response from Redmine RESTful service
    using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
    using (StreamReader reader = new StreamReader(response.GetResponseStream()))
    {
    	Logger.Info("Response from Redmine Issue Tracker: " + reader.ReadToEnd());
    }
