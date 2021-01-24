c#
    public static IEnumerable<IEnumerable<T>> PartitionBy<T>(this IEnumerable<T> a, Func<T, bool> predicate)
	{
		int groupNumber = 0;
		Func<bool, int?> getGroupNumber = skip =>
		{
			if (skip)
			{
                // prepare next group, we don't care if we increment more than once
                // we only want to split groups
				groupNumber++;
                // null, to be able to filter out group separators
				return null;
			}
			return groupNumber;
		};
		return a
		    .Select(x => new { Value = x, GroupNumber = getGroupNumber(predicate(x))} )
    		.Where(x => x.GroupNumber != null)
	    	.GroupBy(x => x.GroupNumber)
		    .Select(g => g.Select(x => x.Value));		
	}
  [1]: https://stackoverflow.com/a/2799543/197371
