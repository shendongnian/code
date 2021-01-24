    public List<Certificates> GetClientsList(string certificationNo = "")
    {
       var query = uow.CertificatesRepository;
       if (string.IsNullOrEmpty(certificationNo))
          return query.Select(n => new Certificates { ClientName = n.Client, ID = n.CertificatesID})
                      .ToList();
    
       return query.Where(x => x.CertificationNo.Contains(certificationNo))
                   .Select(n => new Certificates { ClientName = n.Client, ID = n.CertificatesID})
                   .ToList();
    }
