    public List<Certificates> GetClientsList(string certificationNo = "")
    {
       var query = uow.CertificatesRepository;
       if (string.IsNullOrEmpty(certificationNo))
          return query.ToList();
    
       return query.Where(x => x.CertificationNo.Contains(certificationNo))
                   .ToList();
    }
