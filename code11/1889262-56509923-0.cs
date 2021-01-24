    _dbContext.ServiceRecords
    .Join(x => x.District,district=> district.Id, serviceRecord=> serviceRecord.Id)
    .Join(x=>x.NsepServiceRecords, Nsep=> Nsep.ServiceRecord.Id,district=>district.Id)
    .GroupBy(x => x.DistrictId)
    .Select(x => new DistrictClientsLookUpModel
    {
      DistrictName = x.Select(record => record.District.Name).FirstOrDefault(),
      ClientsServedCount = x.Sum(t=> t.NsepServiceRecords.Count)
    });
   
