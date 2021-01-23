    	private		void UnityPostXML(	int Staging,
    	                             		string WebServer,
    	                             		string MethodName,
    	                             		Hashtable	FieldArray)
    	{
    		string	WebServiceURL	=	"http://LIVESERVER/";
    		if (Staging == 1) {
    			WebServiceURL		=	"http://TESTSERVER";
    		}
    		
    		// Encode the text to a UTF8 byte arrray
    
    		string XMLRequest	=	buildXMLRPCRequest(FieldArray,MethodName);
    		 
    		System.Text.Encoding enc = System.Text.Encoding.UTF8;
    		byte[] myByteArray = enc.GetBytes(XMLRequest);
    		
    		
    		 // Get the Unity WWWForm object (a post version)
    		
    			
    		var form = new WWWForm();
    		var url = WebServiceURL;
    	
    		// 	Add a custom header to the request.
    		//	Change the content type to xml and set the character set
    		var headers = form.headers;
    		headers["Content-Type"]="text/xml;charset=UTF-8";
    	
    		// Post a request to an URL with our rawXMLData and custom headers
    		var www = new WWW(WebServiceURL, myByteArray, headers);
    		
    		//	Start a co-routine which will wait until our servers comes back
    		
    		StartCoroutine(WaitForRequest(www));
    }
    IEnumerator WaitForRequest(WWW www)
    {
        yield return www;
    
        // check for errors
        if (www.error == null)
        {
            Debug.Log("WWW Ok!: " + www.text);
        } else {
            Debug.Log("WWW Error: "+ www.error);
        }    
    }
