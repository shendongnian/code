    public virtual void Insert(TEntity entity, params BaseModel[] unchangedModels)
    {
    	if (entity == null)
    	    throw new ArgumentNullException(nameof(entity));
    
    	try
    	{
    		entity.DateCreated = entity.DateUpdated = DateTime.Now;
    		entity.CreatedBy = entity.UpdatedBy = GetCurrentUser();
    
    		Entities.Add(entity);
    
    		if (unchangedModels != null)
    		{
    			foreach (var model in unchangedModels)
    			{
    				_context.Entry(model).State = EntityState.Unchanged;
    			}
    		}
    
    		_context.SaveChanges();
    	}
    	catch (DbUpdateException exception)
    	{
    		throw new Exception(GetFullErrorTextAndRollbackEntityChanges(exception), exception);
    	}
    }
