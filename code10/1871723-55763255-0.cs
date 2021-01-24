    ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
    ServicePointManager.ServerCertificateValidationCallback += ValidateServerCertificate;
    
    ...
    
    private static bool ValidateServerCertificate(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
    {
    	// If the certificate is a valid, signed certificate, return true to short circuit any add'l processing.
    	if (sslPolicyErrors == SslPolicyErrors.None)
    	{
    		return true;
    	}
    	else
    	{
    		// cast cert as v2 in order to expose thumbprint prop - if needed
    		var requestCertificate = (X509Certificate2)certificate;
    
    		// init string builder for creating a long log entry
    		var logEntry = new StringBuilder();
    
    		// capture initial info for the log entry
    		logEntry.AppendFormat("SSL Policy Error(s): {0} - Cert Issuer: {1} - SubjectName: {2}",
    		   sslPolicyErrors.ToString(),
    		   requestCertificate.Issuer,
    		   requestCertificate.SubjectName.Name);
    
    		// check for other error types as needed
    		if (sslPolicyErrors == SslPolicyErrors.RemoteCertificateChainErrors) //Root CA problem
    		{
    			// check chain status and log
    			if (chain != null && chain.ChainStatus != null)
    			{
    				// check errors in chain and add to log entry
    				foreach (var chainStatus in chain.ChainStatus)
    				{
    					logEntry.AppendFormat("|Chain Status: {0} - {1}", chainStatus.Status.ToString(), chainStatus.StatusInformation.Trim());
    				}
    			}
    		}
    
    		// replace with your logger
    		MyLogger.Info(logEntry.ToString().Trim());
    	}
    
    	return false;
    }
