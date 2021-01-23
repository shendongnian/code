    string GetWebPageContent(string url)
    {
    	string result = string.Empty;
    	HttpWebRequest request;
    	const int bytesToGet = 1000;
    	request = WebRequest.Create(url) as HttpWebRequest;
    
    	//get first 1000 bytes
    	request.AddRange(0, bytesToGet - 1);
    
    	// the following code is alternative, you may implement the function after your needs
    	using (WebResponse response = request.GetResponse())
    	{
            using (Stream stream = response.GetResponseStream())
            {
                byte[] buffer = new byte[1024];
                int read = stream.Read(buffer, 0, 1000);
                Array.Resize(ref buffer, read);
                return Encoding.ASCII.GetString(buffer);
            }
    	}
    }
