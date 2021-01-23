    var docTypes = _documentRepository.GetAll()                   
    .Where(x => x.Owner.Id == LoggedInUser.Id)                   
    .GroupBy(x => x.DocumentType.Id)
    .Select(groupingById=> 
      new
      {
        Id = groupingById.Key,
        Count = groupingById.Count(),
      })
    .OrderByDescending(x => x.Count);
