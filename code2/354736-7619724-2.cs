    public IEnumerable<Owner> GetOwners()
    {
    	var dic = owners.ToDictionary (o => new {o.OwnerId, o.TypeId}, o => o.TypeValue);
    	foreach (var o in owners.Select(o => new { o.OwnerId, o.OwnerName }).Distinct())
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
