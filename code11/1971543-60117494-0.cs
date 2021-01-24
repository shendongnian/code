    using (X509Chain chain = new X509Chain())
    {
        // Use the default vales of chain.ChainPolicy including:
        //  RevocationMode = X509RevocationMode.Online
        //  RevocationFlag = X509RevocationFlag.ExcludeRoot
        //  VerificationFlags = X509VerificationFlags.NoFlag
        //  VerificationTime = DateTime.Now
        //  UrlRetrievalTimeout = new TimeSpan(0, 0, 0)
 
        bool verified = chain.Build(cert);
 
        for (int i = 0; i < chain.ChainElements.Count; i++)
        {
            chain.ChainElements[i].Certificate.Dispose();
        }
 
        return verified;
    }
