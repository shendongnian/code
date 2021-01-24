    public static class BidVehiclesExt
    {
    	public static IEnumerable<BidVehicle> ApplyFilter<TProp>(this IEnumerable<BidVehicle> list, List<TProp> filter, Func<BidVehicle, TProp> prop)
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
    	.ApplyFilter(MakeList, x => x.Vehicle.Make)
    	.ApplyFilter(TrimList, x => x.Vehicle.Trim).ToList();
