    // url is a string where the request is going.
    HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
    // Do what you have to do with the Request.
    
    StringBuilder builder = new StringBuilder();
    int toRead = 1000;
    
    using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
    {
        HttpStatusCode status = response.StatusCode;
        using (Stream receiveStream = response.GetResponseStream())
        {
            using (StreamReader readStream = new StreamReader(receiveStream, Encoding.GetEncoding("utf-8")))
		    {
			    Char[] read = new Char[toRead];
			    int count = readStream.Read(read, 0, toRead);
			
			    while (count > 0)
			    {
				    string str = new String(read, 0, count);
				    builder.Append(str);
				    count = readStream.Read(read, 0, toRead);
			    }
			    readStream.Close();
		    }   
        }
        response.Close();
    }
    
    return builder.ToString();
