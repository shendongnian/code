    using (RSACryptoServiceProvider rsa = <same as above>)
    {
        // Delete this key on Dispose / finalization.
        rsa.PersistKeyInCsp = false;
        CertificateRequest req = ...;
        using (X509Certificate2 cert = req.CreateSelfSigned(...))
        {
            // At this line the persisted key still exists so it reports its name and CSP/KSP into the PFX.
            return cert.Export(X509ContentType.Pkcs12, password);
        }
    }
