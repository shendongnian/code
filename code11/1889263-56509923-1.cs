    _dbContext.ServiceRecords
    .Join( _dbContext.District,district=> district.Id, serviceRecord=> serviceRecord.Id)
    .Join(_dbContext.NsepServiceRecords, Nsep=> Nsep.ServiceRecord.Id,district=>district.Id)
    .GroupBy(x => x.DistrictId)
    .Select(x => new DistrictClientsLookUpModel
    {
      DistrictName = x.Select(record => record.District.Name).FirstOrDefault(),
      ClientsServedCount = x.Sum(t=> t.NsepServiceRecords.Count)
    });
   
