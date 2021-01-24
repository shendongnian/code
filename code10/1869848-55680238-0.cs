    public async Task<List<T>> GetAsync<T>(params Expression<Func<T, bool>>[] filters)
    {
    	IQueryable<T> query = _context.Set<T>();	
    	
    	if(filters != null)
    	{
    		foreach (var filter in filters)
    		{
    			query = query.Where(filter);
    		}
    	}
    	
    	return await query.ToListAsync();
    }
