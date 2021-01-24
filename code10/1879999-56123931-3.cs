    public List<(int ID , string ClientName)> GetClientsList(string certificationNo = "")
    {
       var query = uow.CertificatesRepository;
       if (string.IsNullOrEmpty(certificationNo))
          return query.Select(n => (ID = n.CertificatesID, ClientName = n.Client))
                      .ToList();
    
       return query.Where(x => x.CertificationNo.Contains(certificationNo))
                   .Select(n => (ID = n.CertificatesID, ClientName = n.Client))
                   .ToList();
    }
