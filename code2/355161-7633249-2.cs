      X509Certificate2Collection col = store.Certificates.Find(X509FindType.FindBySubjectName, "yoursubjectname", false);
      X509Chain ch = new X509Chain();
      ch.Build(col[0]);
      X509Certificate2Collection allCertsInChain = new X509Certificate2Collection();
      foreach (X509ChainElement el in ch.ChainElements)
      {
        allCertsInChain.Add(el.Certificate);
      }
      store.RemoveRange(allCertsInChain);
