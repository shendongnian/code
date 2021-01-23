    var comparer = new ThingEqualityComparer();
    
    Console.WriteLine(comparer.Equals(new Thing() { Id = 1, Name = "1" }, new Thing() { Id = 1, Name = "1" }));
    Console.WriteLine(comparer.Equals(new Thing() { Id = 1, Name = "1" }, new Thing() { Id = 2, Name = "2" }));
    Console.WriteLine(comparer.Equals(new Thing() { Id = 1, Name = "1" }, null));
    class ThingEqualityComparer : IEqualityComparer<Thing>
    {
    	public bool Equals(Thing x, Thing y)
    	{
    		if (x == null || y == null)
    			return false;
    
    		return (x.Id == y.Id && x.Name == y.Name);
    	}
    
    	public int GetHashCode(Thing obj)
    	{
    		return obj.GetHashCode();
    	}
    }
