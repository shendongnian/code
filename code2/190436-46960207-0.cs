        if (certificate.Issuer.Equals(certificate.Subject))
        {
            using (X509Store store = new X509Store(StoreName.Root, StoreLocation.LocalMachine)) { 
                store.Open(OpenFlags.ReadWrite);
                store.Add(certificate);
                store.Close();
            }
        }
        using (X509Store store = new X509Store(StoreName.My, StoreLocation.LocalMachine)){ 
            store.Open(OpenFlags.ReadWrite);
            store.Add(certificate);
            store.Close();
        }
