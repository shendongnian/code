    string sResponse = string.Empty;
    try {
    	Uri uri = new Uri(sFetchURL);
    	if (uri.Scheme == Uri.UriSchemeHttp) {
    
    		HttpWebRequest request = null;
    		request = (HttpWebRequest) HttpWebRequest.Create(uri);
    
    		request.Method = WebRequestMethods.Http.Get;
    		request.ContentType = "text/xml;charset=\"utf-8\"";
    
            string strSOAPRequestBody = "<SOAP-ENV:Envelope xmlns:SOAP-ENV=\"http://schemas.xmlsoap.org/soap/envelope/\" xmlns:ak=\"http://Link.JavaService\">" +
             "<SOAP-ENV:Header>" +
              "<ak:password>" + myPassword + "</ak:password>" +
              "<ak:username>" + myUserName + "</ak:username>" +
             "</SOAP-ENV:Header>" +
             "<SOAP-ENV:Body>" +
              "<ak:Vehicle>" +
                 "<chassisNo>" + sChessisNo + "</chassisNo>" +
                 "<plateNo>" + sPlateNo + "</plateNo>" +
                 "<plateCode>" + sPlateCode + "</plateCode>" +
              "</ak:passingVehicleTest>" +
             "</SOAP-ENV:Body>" +
            "</SOAP-ENV:Envelope>";
    		
    		request.Method = "POST";
    		request.ContentType = "application/soap-xml; charset=UTF-8";
    		request.Headers.Add("SOAPAction:\"\"");
    
    		request.ContentLength = strSOAPRequestBody.Length;
    		System.IO.StreamWriter streamWriter = new System.IO.StreamWriter(
    				request.GetRequestStream());
    		streamWriter.Write(strSOAPRequestBody);
    		streamWriter.Close();
    		System.IO.StreamReader streamReader = new System.IO.StreamReader(
    				request.GetResponse().GetResponseStream());
    		
    		while (!streamReader.EndOfStream)
    			sResponse += streamReader.ReadLine();
    	}
    
    } catch (WebException err) {
    	HttpWebResponse httpResponse = null;
    	httpResponse = (HttpWebResponse) err.Response;
    	Stream baseStream = httpResponse.GetResponseStream();
    
    	System.IO.StreamReader streamReader2 = new System.IO.StreamReader(
    			baseStream);
    	while (!streamReader2.EndOfStream)
    		sResponse += streamReader2.ReadLine();
    }
    
    return sResponse;
