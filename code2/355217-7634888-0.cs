    X509Store store = new X509Store(StoreName.My, StoreLocation.CurrentUser);
    store.Open(OpenFlags.ReadOnly | OpenFlags.IncludeArchived);
    foreach (var c in store.Certificates)
    {
      Console.Out.WriteLine(c.Thumbprint);
      Console.Out.WriteLine(c.Subject);
    }
    
    // Find by thumbprint
    X509Certificate2Collection col =
    store.Certificates.Find(X509FindType.FindByThumbprint, "669502F7273C447A62550D41CD856665FBF23E48", false);
    store.Close();
