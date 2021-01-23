    	private 	string NormalXMLCall(int Staging,
    										 string WebServer,
    										 string MethodName,
    										 Hashtable Fields)
    	{
    		//	Figure out who to call
    		string	WebServiceURL	=	"http://LIVSERVER";
    		if (Staging == 1) {
    			WebServiceURL		=	"http://TESTSERVER";
    		}
    		
    		WebServiceURL			+=	WebServer;
    		
    		//	Build the request
    		
    		XmlRpcParser	parser	=	new XmlRpcParser();
    		string XMLRequest 		= parser.buildXMLRPCRequest(Fields,MethodName);
    		
    		//	Fire it off
    		
    		HttpWebRequest httpRequest =(HttpWebRequest)WebRequest.Create(WebServiceURL);
    
    		httpRequest.Method = "POST";
    
    		//Defining the type of the posted data as XML
    		httpRequest.ContentType = "text/xml";
    
    		// string data = xmlDoc.InnerXml;
    		byte[] bytedata = Encoding.UTF8.GetBytes(XMLRequest);
    		
    		// Get the request stream.
    		Stream requestStream = httpRequest.GetRequestStream();
    		
    		// Write the data to the request stream.
    		requestStream.Write(bytedata, 0, bytedata.Length);
    		requestStream.Close();
    		
    		//Get Response
    		HttpWebResponse httpResponse = (HttpWebResponse)httpRequest.GetResponse();
    		
    	 	// Get the stream associated with the response.
            Stream receiveStream = httpResponse.GetResponseStream ();
    
            // Pipes the stream to a higher level stream reader with the required encoding format. 
            StreamReader readStream = new StreamReader (receiveStream, Encoding.UTF8);
    
            string	ReceivedData	=	readStream.ReadToEnd ();
            httpResponse.Close ();
            readStream.Close ();
    		
    		return	ReceivedData;
    	}
    }
