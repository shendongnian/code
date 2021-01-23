    static bool VerifyServerCertificate(object sender, X509Certificate certificate,
        X509Chain chain, SslPolicyErrors sslPolicyErrors)
    {
        try
        {
            String CA_FILE = "ca-cert.der";
            X509Certificate2 ca = new X509Certificate2(CA_FILE);
    
            X509Chain chain2 = new X509Chain();
            chain2.ChainPolicy.ExtraStore.Add(ca);
    
            // Check all properties
            chain2.ChainPolicy.VerificationFlags = X509VerificationFlags.NoFlag;
    
            // This setup does not have revocation information
            chain2.ChainPolicy.RevocationMode = X509RevocationMode.NoCheck;
    
            // Build the chain
            chain2.Build(new X509Certificate2(certificate));
            // Are there any failures from building the chain?
            if (chain2.ChainStatus.Length == 0)
                return true;
    
            // If there is a status, verify the status is NoError
            bool result = chain2.ChainStatus[0].Status == X509ChainStatusFlags.NoError;
            Debug.Assert(result == true);
    
            return result;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
        }
    
        return false;
    }
