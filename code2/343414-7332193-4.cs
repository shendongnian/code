    static bool VerifyCertificate(byte[] primaryCertificate, IEnumerable<byte[]> additionalCertificates)
    {
        var chain = new X509Chain();
        foreach (var cert in additionalCertificates.Select(x => new X509Certificate2(x)))
        {
            chain.ChainPolicy.ExtraStore.Add(cert);
        }
        // You can alter how the chain is built/validated.
        chain.ChainPolicy.RevocationMode = X509RevocationMode.NoCheck;
        chain.ChainPolicy.VerificationFlags = X509VerificationFlags.IgnoreWrongUsage;
        // Do the preliminary validation.
        var primaryCert = new X509Certificate2(primaryCertificate);
        if (!chain.Build(primaryCert))
            return false;
        // Make sure we have the same number of elements.
        if (chain.ChainElements.Count != chain.ChainPolicy.ExtraStore.Count + 1)
            return false;
        // Make sure all the thumbprints of the CAs match up.
        // The first one should be 'primaryCert', leading up to the root CA.
        for (var i = 1; i < chain.ChainElements.Count; i++)
        {
            if (chain.ChainElements[i].Certificate.Thumbprint != chain.ChainPolicy.ExtraStore[i - 1].Thumbprint)
                return false;
        }
        return true;
    }
