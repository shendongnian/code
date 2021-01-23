    //Execute the request
    HttpWebResponse response = null;
    try
    {
        response = (HttpWebResponse)request.GetResponse();
    }
    catch (WebException we) { // handle web excetpions }
    catch (Exception e) { // handle other exceptions }
    this.Response.ContentType = "application/pdf";
		
	const int BUFFER_SIZE = 1024;
	byte[] buffer = new byte[BUFFER_SIZE];
	int bytes = 0;
	while ((bytes = resStream.Read(buffer, 0, BUFFER_SIZE)) > 0)
	{
		//Write the stream directly to the client 
		this.Response.OutputStream.Write(buff, 0, bytes);
	}
