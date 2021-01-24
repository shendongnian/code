    public static class Extensions
    {
    	public static int[] getIdsOfPages<TSource>(this IQueryable<TSource> list, Expression<Func<TSource, int>> select, Expression<Func<int, bool>> filter)
    	{
    		return list
    			.Select(select)
    			.Where(filter)
    			.Distinct()
    			.ToArray();
    	}
    }
