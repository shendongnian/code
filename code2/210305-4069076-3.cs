    var tblSerials = new [] {
    new { CreateDate = DateTime.Today.AddDays(-2), SerialGUID = "foo" },
    new { CreateDate = DateTime.Today.AddDays(-3), SerialGUID = "bar" },
    new { CreateDate = DateTime.Today.AddDays(-2), SerialGUID = "foobar" },
    new { CreateDate = DateTime.Today.AddDays(-1), SerialGUID = "foo" }
    };
    
    var tblRequests = new [] {
    new { SerialGUID = "foo", RequestGUID = "hi", MachineCode = "1" },
    new { SerialGUID = "bar", RequestGUID = "yo", MachineCode = "2" },
    new { SerialGUID = "foo", RequestGUID = "hello", MachineCode = "1" },
    new { SerialGUID = "baz", RequestGUID = "yeah", MachineCode = "3" }
    };
    
    tblSerials
    	.Join(
    		tblRequests,
    		x => x.SerialGUID.ToLower(),
    		x => x.SerialGUID.ToLower(),
    		(o,i) => new { Serial = o, Request = i }
    	).GroupBy(x => x.Serial)
    	.Select(x => new {
    		SerialGUID = x.Key.SerialGUID,
    		CreateDate = x.Key.CreateDate,
    		NumberOfAllRequests = x.Select(y => y.Request.RequestGUID).Count(),
    		NumberOfAllRequestsDistinctByMachine = x.Select(y => y.Request.MachineCode).Distinct().Count()
    	}).OrderByDescending(x => x.CreateDate).Dump();
    	
    (from s in tblSerials
    from r in tblRequests
    	.Where(x => x.SerialGUID.ToLower().Equals(s.SerialGUID.ToLower()))
    	.DefaultIfEmpty()
    select new { Serial = s, Request = r })
    .GroupBy(x => x.Serial)
    	.Select(x => new {
    		SerialGUID = x.Key.SerialGUID,
    		CreateDate = x.Key.CreateDate,
    		NumberOfAllRequests = x.Any(y => y.Request != null) ? x.Select(y => y.Request.RequestGUID).Count() : 0,
    		NumberOfAllRequestsDistinctByMachine = x.Any(y => y.Request != null) ? x.Select(y => y.Request.MachineCode).Distinct().Count() : 0
    	}).OrderByDescending(x => x.CreateDate).Dump();
    	
    tblSerials
    	.ToList().Select(x => {
    	var requests = tblRequests.Where(y => y.SerialGUID.ToLower().Equals(x.SerialGUID.ToLower()));
    	return 	new {
    				SerialGUID = x.SerialGUID,
    				CreateDate = x.CreateDate,
    				NumberOfAllRequests = requests.Count(),
    				NumberOfAllRequestsDistinctByMachine = requests.Select(y => y.MachineCode).Distinct().Count()
    			};
    	}).OrderByDescending(x => x.CreateDate).Dump();
    
    var list = from s in tblSerials
    		orderby s.CreateDate descending
    		select new
    		{
    		 SerialGUID = s.SerialGUID,
    		 CreateDate = s.CreateDate,
    		 NumberOfAllRequests = 
    			(from request in tblRequests
    			  where request.SerialGUID.ToLower().Equals(s.SerialGUID.ToLower())
    			  select request.RequestGUID).Count(),
    		 NumberOfAllRequestsDistinctByMachine = 
    			(from request in tblRequests
    			  where request.SerialGUID.ToLower().Equals(s.SerialGUID.ToLower())
    			  select request.MachineCode).Distinct().Count(),                    
    		};
    		
    list.Dump();
