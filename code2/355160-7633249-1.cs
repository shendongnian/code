    // Use other store locations if your certificate is not in the current user store.
    X509Store store = new X509Store(StoreName.My, StoreLocation.CurrentUser);
    store.Open(OpenFlags.ReadWrite | OpenFlags.IncludeArchived);
      
    // You could also use a more specific find type such as X509FindType.FindByThumbprint
    X509Certificate2Collection col = store.Certificates.Find(X509FindType.FindBySubjectName, "yoursubjectname", false);
    foreach (var cert in col)
    {
      Console.Out.WriteLine(cert.SubjectName.Name);
      // Remove the certificate
      store.Remove(cert);        
    }
    store.Close();
