    using Microsoft.Web.Administration;  
  
    X509Store store = new X509Store(StoreName.My, StoreLocation.LocalMachine);
    store.Open(OpenFlags.OpenExistingOnly | OpenFlags.ReadWrite);
    
    X509Certificate2 certificate = new X509Certificate2(pfxFilePath);
    
    store.Add(certificate);
    
    using (ServerManager serverManager = new ServerManager())
    {
        Site site = serverManager.Sites["Default Web Site"];
               
        if (site != null)
        {
             site.Bindings.Add("*:443:", certificate.GetCertHash(), store.Name);
        }
    
        store.Close();
    }
