	try
	{
		request.Method = "HEAD";
		var response = request.GetResponse();
		if (response != null)
		{
			Console.WriteLine(request.GetResponse().ResponseUri);
		}
	}
	catch (WebException webEx) {
		// Now you can access webEx.Response object that contains more info on the server response              
	   if(webEx.Status == WebExceptionStatus.ProtocolError) {
			Console.WriteLine("Status Code : {0}", ((HttpWebResponse)webEx.Response).StatusCode);
			Console.WriteLine("Status Description : {0}", ((HttpWebResponse)webEx.Response).StatusDescription);
        }
	}
	catch (Exception exception) {
		Console.WriteLine(exception.Message);                
	}
