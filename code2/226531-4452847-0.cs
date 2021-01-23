    try
    {
    	WebClient webClient = new WebClient();
    	byte[] rawResponse = webClient.UploadFile(url,fileName);
    
    	string response = System.Text.Encoding.ASCII.GetString(rawResponse);
    
    	...
    	Your response validation code
    	...
    }
    catch (WebException wexc)
    {
    	...
    	Handle Web Exception
    	...
    }
