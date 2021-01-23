    public IEnumerable<Owner> GetOwners(IEnumerable<Tuple<int, int>> filter)
    {
        var q = (from o in owners
                join f in filter on 
                   new {o.TypeId, o.TypeCodeId} equals 
                   new {TypeId = f.Item1, TypeCodeId = f.Item2}
                select o).ToList();
    	var dic = q.ToDictionary (o => new {o.OwnerId, o.TypeId}, o => o.TypeValue);
    	foreach (var o in q.Select(o => new { o.OwnerId, o.OwnerName }).Distinct())
    	{
    		var owner = new Owner()
    		{
    			OwnerId = o.OwnerId,
    			Name = o.OwnerName
    		};
    		string lookup;
    		if(dic.TryGetValue(new {o.OwnerId, TypeId = 1}, out lookup))
    			owner.Area = lookup;
    		if(dic.TryGetValue(new {o.OwnerId, TypeId = 2}, out lookup))
    			owner.City = lookup;
    		if(dic.TryGetValue(new {o.OwnerId, TypeId = 3}, out lookup))
    			owner.Sex = lookup;
    
    		yield return owner;
    	}
    }
