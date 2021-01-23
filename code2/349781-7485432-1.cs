    public delegate bool RemoteCertificateValidationCallback(
        Object sender,
        X509Certificate certificate,
        X509Chain chain,
        SslPolicyErrors sslPolicyErrors)
