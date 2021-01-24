C#
    public struct IdAndValue {	// Example data structure
		public int id;
		public double val;
	}
	
	static IEnumerable<IdAndValue> findAllMinimums(ICollection<IdAndValue> data)
	{
		var byValue = data.ToLookup(d => d.val);
		return byValue[byValue.Min(grp => grp.Key)];
	}
To get a list, do ```findAllMinimums(...).ToList()```.
