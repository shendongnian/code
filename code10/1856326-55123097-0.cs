    public returnObject PostFromThirdPartyObject(Stream jsonStream)
    {
            string sRequest = String.Empty;
            StreamReader stmRequest = new StreamReader(input, System.Text.Encoding.UTF8);
            sRequest = stmRequest.ReadToEnd();
            ThirdPartyObject obj = null;
    		try{
		        obj = JsonConvert.DeserializeObject<ThirdPartyObject>(sRequest)
		       }
		    catch
		    {
		       //you have the object posted by your client in sRequest
		       //do whatever you want
		    }
        
        // obj is your object to process
        // Process Object
        return returnObject;
    }
