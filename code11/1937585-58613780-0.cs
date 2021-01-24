    public IQueryable<CategoryDTO> Categories
    {
    	get
    	{
    		//return _mapper.Map<IQueryable<CategoryDTO>>(_context.Categories);
    		return _context.Categories.ProjectTo<CategoryDTO>(_mapper.ConfigurationProvider).AsQueryable();
    	}
    }
