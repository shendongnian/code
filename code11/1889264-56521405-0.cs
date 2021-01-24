    var query = _dbContext.Districts
    	.Select(d => new DistrictClientsLookUpModel
    	{
    		DistrictName = d.Name,
    		ClientsServedCount = d.ServiceRecords
    			.Where(s => s.CreatedAtUtc >= startUniversalTime && s.CreatedAtUtc <= endUniversalTime)
    			.SelectMany(s => s.NsepServiceRecords)
    			.Select(r => r.ClientRegNo).Distinct().Count()
    	});
