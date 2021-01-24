    using (X509Certificate2 filter = new X509Certificate2(file))
    using (X509Store store = new X509Store(StoreName.My, StoreLocation.CurrentUser))
    {
        store.Open(OpenFlags.ReadOnly);
        // The bytes making up the certificate, in DER/binary form.
        byte[] filterRawData = filter.RawData;
        foreach (X509Certificate2 storeCert in store.Certificates)
        {
            if (storeCert.RawData.SequenceEquals(filterRawData))
            {
                File.WriteAllBytes(outputFileName, storeCert.Export(X509ContentType.Pfx, password));
                return;
            }
        }   
    }
    Console.WriteLine("No match found...");
