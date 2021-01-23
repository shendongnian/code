	private IQueryable<Auditing> MakeOrderedQuery<T>(IQueryable<Auditing> query, bool descending, 
		Expression<Func<Auditing, T>> keyselector)
	{
		if (descending)
		{
			return query.OrderByDescending(keyselector);
		}
		else
		{
			return query.OrderBy(keyselector);
		}
	}
