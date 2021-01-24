      var errors = new List<string>();
      var chain = new X509Chain();
      // certificate is the one you want to check
      chain.Build(certificate);
      // traverse certificate chain
      foreach (var chainElement in chain.ChainElements)
      {
        // ChainElementStatus contains validation errors
        foreach (var status in chainElement.ChainElementStatus)
        {
          errors.Add(status.Status + " " + chainElement.Certificate + ": " + status.StatusInformation.Trim());
        }
      }
