    // address - CA address
    public static void InstallRootCert(string address)
    {
        // getting root cert            
        ICertRequest2 objRequest = new CCertRequest();
        string rootCert = objRequest.GetCACertificate(0, address, 0);
        byte[] buffer = Encoding.UTF8.GetBytes(rootCert);
        // installing
        var store = new X509Store("Root", StoreLocation.CurrentUser);
        store.Open(OpenFlags.OpenExistingOnly | OpenFlags.ReadWrite);
        var root = new X509Certificate2(buffer);
        store.Add(root);
    }
