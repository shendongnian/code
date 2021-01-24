    public List<Certificates> GetClientsList(string certificationNo = "")
            {
                var query = uow.CertificatesRepository.GetQueryable(); // do ToList here if it is IQuerable, but as it seems it was not.
                
                return query.Where(x=>x.CertificationNo.Contains(certificationNo)).Select(x=> new Certificates(){ClientName= n.Client, ID= n.CertificatesID}).ToList();
            }
