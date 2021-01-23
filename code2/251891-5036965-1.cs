    foreach (X509Certificate2 cert in collection)
    {
    	Console.WriteLine("Subject is: '{0}'", cert.Subject);
    	Console.WriteLine("Issuer is:  '{0}'", cert.Issuer);
    
        // Import the certificates into X509Store objects
