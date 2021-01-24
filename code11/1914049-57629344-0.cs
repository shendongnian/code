    X509Certificate2 serverCertificate = null;
    using (X509Store store = new X509Store(StoreName.CertificateAuthority, StoreLocation.CurrentUser))
    {
        store.Open(OpenFlags.ReadWrite);
        X509Certificate2Collection coll = new X509Certificate2Collection();
        coll.Import("certificate.pfx");
        foreach (X509Certificate2 cert in coll)
        {
            if (cert.HasPrivateKey)
            {
                // Maybe apply more complex logic if you really expect multiple private-key certs.
                if (serverCertificate == null)
                {
                    serverCertificate = cert;
                }
                else
                {
                    cert.Dispose();
                }
            }
            else
            {
                // This handles duplicates (as long as no custom properties have been applied using MMC)
                store.Add(cert);
                cert.Dispose();
            }
        }
    }
    // tcpListener, et al.
