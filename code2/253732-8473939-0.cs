    var store = new X509Store(StoreName.My, StoreLocation.LocalMachine);
    store.Open(OpenFlags.OpenExistingOnly);
    var certificate = store.Certificates.Find(X509FindType.FindByThumbprint, the thumbprint for the key", true);
    
    var site = _mgr.Sites[name];
    site.Bindings.Add("*:4043:", certificate[0].GetCertHash(), "MY");
