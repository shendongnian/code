    public static class FilterExt
    {
    	public static IEnumerable<TItem> ApplyFilter<TProp>(this IEnumerable<TItem> list, List<TProp> filter, Func<TItem, TProp> prop)
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
