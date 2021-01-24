    private bool ValidateRemoteCertificate(
        object sender,
        X509Certificate cert,
        X509Chain chain,
        SslPolicyErrors policyErrors)
    {
        if (policyErrors != SslPolicyErrors.None)
        {
            return false;
        }
        if (chain.ChainElements.Count != 3)
        {
            return false;
        }
        byte[] foundCert = chain.ChainElements[1].Certificate.RawData;
        return s_letsEncryptX3Direct.SequenceEqual(foundCert) ||
            s_letsEncryptX3Cross.SequenceEqual(foundCert);
    }
