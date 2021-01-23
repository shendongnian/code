    if ((sslPolicyErrors & SslPolicyErrors.RemoteCertificateNameMismatch) == SslPolicyErrors.RemoteCertificateNameMismatch)
    {
        sslPolicyErrors &= ~SslPolicyErrors.RemoteCertificateNameMismatch;
    }
    
    if ((sslPolicyErrors & SslPolicyErrors.RemoteCertificateChainErrors) == SslPolicyErrors.RemoteCertificateChainErrors)
    {
        var otherFlagsFound =
            from i in chain.ChainStatus
            where (i.Status & ~X509ChainStatusFlags.UntrustedRoot) != X509ChainStatusFlags.NoError
            select i;
    
        if (otherFlagsFound.Count() == 0)
        {
            sslPolicyErrors &= ~SslPolicyErrors.RemoteCertificateChainErrors;
        }
    }
