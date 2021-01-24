    public List<Certificates> GetClientsList(string certificationNo = "")
    {
       List<Certificates> certificatesList = new List<Certificates>();
       var query = uow.CertificatesRepository.GetQueryable().AsQueryable();
       if (!string.IsNullOrEmpty(certificationNo))
       {
           query = query.Where(x => x.CertificationNo.Contains(certificationNo)).Select(n => new Certificates{ Client = n.Client, CertificatesID = n.CertificatesID});
       }
       certificatesList = query.ToList();
       return certificatesList;
    }
