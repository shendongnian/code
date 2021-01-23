    var request = (HttpWebRequest)WebRequest.Create(uri);
    request.Credentials = this.credentials;
    request.Method = method;
    request.ContentType = "application/atom+xml;type=entry";
    using (Stream requestStream = request.GetRequestStream())
    using (var xmlWriter = XmlWriter.Create(requestStream, new XmlWriterSettings() { Indent = true, NewLineHandling = NewLineHandling.Entitize, }))
    {
    	cmisAtomEntry.WriteXml(xmlWriter);
    }
    
    try 
    {	 
    	return (HttpWebResponse)request.GetResponse();	
    }
    catch (WebException wex)
    {
    	var httpResponse = wex.Response as HttpWebResponse;
    	if (httpResponse != null)
    	{
    		throw new ApplicationException(string.Format(
    			"Remote server call {0} {1} resulted in a http error {2} {3}.",
    			method,
    			uri,
    			httpResponse.StatusCode,
    			httpResponse.StatusDescription), wex);
    	}
    	else
    	{
    		throw new ApplicationException(string.Format(
    			"Remote server call {0} {1} resulted in an error.",
    			method,
    			uri), wex);
    	}
    }
    catch (Exception)
    {
    	throw;
    }
