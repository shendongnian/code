    string username = "user";
    string password = "password";
    
    var request = (HttpWebRequest)WebRequest.Create("http://serverIP/ast/ASTIsapi.dll?GetPreCannedInfo&Items=getServiceInfoRequest");
    request.ContentType = "text/xml; charset=utf-8";
    request.Accept = "text/xml";
    request.Method = "POST";
    request.Headers.Add("SOAPAction", "yourSoapAction"); // you can get it from SoapUI if you don't know it.
    request.Headers.Add("Authorization", "Basic " + System.Convert.ToBase64String(Encoding.ASCII.GetBytes(username + ":" + password)));
    // OR you can use NetworkCredential 
    // request.Credentials = new NetworkCredential("user", "password");
    	
    // Simpler method to bypass the certificate validation errors
    ServicePointManager.ServerCertificateValidationCallback += delegate { return true; };
    
    // Use this to set the HTTP Protocol Version
    request.ProtocolVersion = HttpVersion.Version10;
    /*
     * Empty Standard Soap Envelope
     */
    XNamespace soapenv = @"http://schemas.xmlsoap.org/soap/envelope";
    
    XDocument body = new XDocument(
    	new XElement(soapenv + "Envelope",
    		new XAttribute(XNamespace.Xmlns + "soapenv", soapenv),
    		new XElement(soapenv + "Header"),
    		new XElement(soapenv + "Body")
    	 ));
    
    // Since it's POST, it's required to have body, if SoapUI generated an empty body, then create empty XDocument and pass it. 
    using (var sw = new StreamWriter(request.GetRequestStream(), Encoding.UTF8))
    	using (var httpresponse = (HttpWebResponse)request.GetResponse())
    		using (var reader = new StreamReader(httpresponse.GetResponseStream()))
    		{
    			sw.Write(body);
    			File.WriteAllText("services.xml", reader.ReadToEnd().ToString());
    		}
