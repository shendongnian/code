	var OrderBy = new Dictionary<string, IQueryable<Something>>
	{
		(...)
		
		{ "DateDifference", input.OrderDirection == "asc" 
                            ?
							input.OrderBy(x => 
							(x.Date1 == null ? new DateTime(0) : x.Date1.Value.Date)
							-
							(x.Date2 == null ? new DateTime(0) : x.Date2.Value.Date)) 
                            :
							input.OrderByDescending(x => 
							(x.Date1 == null ? new DateTime(0) : x.Date1.Value.Date)
							-
							(x.Date2 == null ? new DateTime(0) : x.Date2.Value.Date)) },
	};
