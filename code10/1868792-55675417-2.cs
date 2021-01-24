    public virtual TEntity SelectFromContext(TPrimaryKey id)
    {
    	TEntity entity;
    	entity = Repository.GetDbContext().Set<TEntity>().SingleOrDefault(e => e.Id.Equals(id));
    	return entity;
    }
    
    public virtual async Task<TEntity> UpdateWithExclude(TEntity entity, string[] properities)
    {
    		if (entity == null)
    			throw new ArgumentException("Paramter cannot be null", "entity");
    
    		var existedEntity = SelectFromContext(entity.Id);
    		if (existedEntity == null)
    			throw new ObjectNotFoundException("Record is not found!");
    
    		var currentValues = Repository.GetDbContext().Entry(existedEntity).CurrentValues;
    
    		foreach (var properteyName in currentValues.PropertyNames)//make default false value for all 
    		{
    			var y = Repository.GetDbContext().Entry(existedEntity).Property(properteyName);
    			if (!properities.Contains(y.Name))
    				Repository.GetDbContext().Entry(existedEntity).Property(properteyName).IsModified = false;
    		}
    
    		Repository.GetDbContext().Entry(existedEntity).CurrentValues.SetValues(entity);
    
    		Repository.GetDbContext().SaveChanges();
    		var UpdatedEntity = SelectFromContext(entity.Id);
    		return await Task.FromResult(UpdatedEntity);
    }
