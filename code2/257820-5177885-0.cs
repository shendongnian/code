    //Execute the request
    HttpWebResponse response = (HttpWebResponse)request.GetResponse();
		
	const int BUFFER_SIZE = 1024;
	byte[] buffer = new byte[BUFFER_SIZE];
	int bytes = 0;
	while ((bytes = resStream.Read(buffer, 0, BUFFER_SIZE)) > 0)
	{
		//Write the stream directly to the client 
		this.Response.OutputStream.Write(buff, 0, bytes);
	}
