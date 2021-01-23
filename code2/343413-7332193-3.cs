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
            
        // Do the validation.
        var primaryCert = new X509Certificate2(primaryCertificate);
        return chain.Build(primaryCert);
    }
