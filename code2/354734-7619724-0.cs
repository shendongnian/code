    public IEnumerable<Owner> GetOwners()
    {
    	var dic = owners.ToDictionary (o => new Tuple<int, int>(o.OwnerId, o.TypeId), o => o.TypeValue);
    	foreach (var o in owners.Select(o => new { o.OwnerId, o.OwnerName }).Distinct())
    	{
    		var owner = new Owner()
    		{
    			OwnerId = o.OwnerId,
    			Name = o.OwnerName
    		};
            string lookup;
    		if(dic.TryGetValue(new Tuple<int, int>(o.OwnerId, 1), out lookup))
    			owner.Area = lookup;
    		if(dic.TryGetValue(new Tuple<int, int>(o.OwnerId, 2), out lookup))
    			owner.City = lookup;
    		if(dic.TryGetValue(new Tuple<int, int>(o.OwnerId, 3), out lookup))
    			owner.Sex = lookup;
    		yield return owner;
    	}
    }
