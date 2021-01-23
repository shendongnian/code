    public bool ValidateServerCertificate(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
    {
    	Console.WriteLine(sslPolicyErrors);  // Or whatever you want to do...
    	return true;
    }
