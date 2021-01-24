    public static class BidVehiclesExt
    {
    	public static IEnumerable<BidVehicle> ApplyFilter(this IEnumerable<BidVehicle> list, List<string> filter, Func<BidVehicle, string> prop)
    	{
    		if (filter == null || filter.Count == 0)
    		{
    			return list;
    		}
    
    		return list.Where(x => filter.Contains(prop.Invoke(x)));
    	}
    }
    
    ... 
     
    var filtered = bidVehicles
    	.ApplyFilter(MakeList, x => b.Vehicle.Make)
    	.ApplyFilter(TrimList, x => b.Vehicle.Trim).ToList();
