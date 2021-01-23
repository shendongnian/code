      X509Store store = new X509Store(StoreName.Root,StoreLocation.LocalMachine);
            store.Open(OpenFlags.ReadOnly);
            X509Certificate cert = new X509Certificate();
            for (int i = 0; i < store.Certificates.Count; i++)
            {
                if (store.Certificates[i].SerialNumber == "XXXX")
                {
                    cert = store.Certificates[i];
                }
            }
