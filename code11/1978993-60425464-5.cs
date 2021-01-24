    var groupedByIdAndDistrictData = (from so in _companysalesRepo.QueryNoTracking
                                        join en in _entityRepo.QueryNoTracking on so.PharmacyId equals en.Id
                                        join ad in _addressRepo.QueryNoTracking on so.PharmacyId equals ad.EntityId
                                        
                                        group so by new {
                                        	so.Id,
                                        	ad.DistrictId
                                        }
                                        into totaledeorders
                                        
                                        select new Salescities {
                                        	Totaledvalue = totaledeorders.Sum(s = >s.TotalCost),
                                        	District = totaledeorders.Key.DistrictId.ToString()
                                        }).ToList();
    
    var resultsalescity = groupedByIdAndDistrictData.GroupBy(p = >p.District)
                                        .Select(g = >new Salescities {
                                        	Totaledvalue = g.Sum(s = >s.Totaledvalue),
                                        	District = g.Key
                                        }).ToList();
    
    return resultsalescity;
