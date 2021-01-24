    private static bool IsExpectedRootPin(X509Chain chain)
    {
        X509Certificate2 lastCert = chain.ChainElements[chain.ChainElements.Count - 1].Certificate;
        return lastCert.RawBytes.SequenceEquals(s_pinnedRootBytes);
    }
    private static bool ValidateServerCertificate(
        object sender,
        X509Certificate certificate,
        X509Chain chain,
        SslPolicyErrors sslPolicyErrors
    )
    {
        if ((sslPolicyErrors & ~SslPolicyErrors.RemoteCertificateChainErrors) != 0)
        {
            // No cert, or name mismatch (or any future errors)
            return false;
        }
        if (IsExpectedRootPin(chain))
        {
            return true;
        }
        chain.ChainPolicy.ExtraStore.Add(s_intermediateCert);
        chain.ChainPolicy.ExtraStore.Add(s_pinnedRoot);
        chain.ChainPolicy.VerificationFlags |= X509VerificationFlags.AllowUnknownCertificateAuthority;
        if (chain.Build(chain.ChainElements[0].Certificate))
        {
            return IsExpectedRootPin(chain);
        }
        return false;
    }
