    public static string XmlHttpRequest(string urlString, string xmlContent)
    {
    	string response = null;
		HttpWebRequest httpWebRequest = null;//Declare an HTTP-specific implementation of the WebRequest class.
		HttpWebResponse httpWebResponse = null;//Declare an HTTP-specific implementation of the WebResponse class
		//Creates an HttpWebRequest for the specified URL.
		httpWebRequest = (HttpWebRequest)WebRequest.Create(urlString);
		try
		{
			byte[] bytes;
			bytes = System.Text.Encoding.ASCII.GetBytes(xmlContent);
			//Set HttpWebRequest properties
			httpWebRequest.Method = "POST";
			httpWebRequest.ContentLength = bytes.Length;
			httpWebRequest.ContentType = "text/xml; encoding='utf-8'";
			using (Stream requestStream = httpWebRequest.GetRequestStream())
			{
				//Writes a sequence of bytes to the current stream 
				requestStream.Write(bytes, 0, bytes.Length);
				requestStream.Close();//Close stream
			}
			//Sends the HttpWebRequest, and waits for a response.
			httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
			if (httpWebResponse.StatusCode == HttpStatusCode.OK)
			{
				//Get response stream into StreamReader
				using (Stream responseStream = httpWebResponse.GetResponseStream())
				{
					using (StreamReader reader = new StreamReader(responseStream))
						response = reader.ReadToEnd();
				}
			}
			httpWebResponse.Close();//Close HttpWebResponse
		}
		catch (WebException we)
		{   //TODO: Add custom exception handling
			throw new Exception(we.Message);
		}
		catch (Exception ex) { throw new Exception(ex.Message); }
		finally
		{
			httpWebResponse.Close();
			//Release objects
			httpWebResponse = null;
			httpWebRequest = null;
		}
		return response;
	}
