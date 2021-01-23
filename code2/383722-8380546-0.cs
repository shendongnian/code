    public class MyWebService : 
    	WebService
    {
    	[WebMethod]
    	public string GetXml(string apiKey) 
    	{ 
    		if( isApiKeyValid(apiKey) )
    		{
    			var doc = new XmlDocument();
    
    			// TODO: generate XML document.
    			
    			return doc.OuterXml;
    		}
    		else
    		{
    			throw new Exception("Invalid API key.");
    		}
    	}
    }
