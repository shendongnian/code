    static void HTTPSClient()
    {
    	try
    	{
    		string message = "GET / HTTP/1.0\r\nHost: host.com\r\n\r\n";
    
    		byte[] data = System.Text.Encoding.ASCII.GetBytes(message);
    
    		string server = "host.com";
    		int nPort = 443;
    		TcpClient client = new TcpClient(server, nPort);
    
    		X509Certificate2Collection cCollection = new X509Certificate2Collection();
    		cCollection.Add(new X509Certificate2("cert.pfx", "password"));
    
    
    		using (SslStream sslStream = new SslStream(client.GetStream(), false, new RemoteCertificateValidationCallback(ValidateServerCertificate), null))
    		{
    			// Add a client certificate to the ssl connection
    			sslStream.AuthenticateAsClient(server, cCollection, System.Security.Authentication.SslProtocols.Default, true);
    
    			sslStream.Write(data, 0, data.Length);
    
    			data = new Byte[8192];
    			int bytes = 0;
    			string responseData = "";
    
    			do
    			{
    				bytes = sslStream.Read(data, 0, data.Length);
    				if (bytes > 0)
    				{
    					responseData += System.Text.Encoding.ASCII.GetString(data, 0, bytes);
    				}
    			}
    			while (bytes > 0);
    
    			Console.WriteLine("Response: " + responseData);
    		}
    
    		// Disconnect and close the client
    		client.Close();
    	}
    	catch (Exception ex)
    	{
    		Console.WriteLine("Error: " + ex.ToString());
    	}
    }
    
    public static bool ValidateServerCertificate(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
    {
    	if (sslPolicyErrors == SslPolicyErrors.None)
    		return true;
    
    	Console.WriteLine("Certificate error: {0}", sslPolicyErrors);
    
    	// Do not allow this client to communicate with unauthenticated servers.
    	return false;
    }
