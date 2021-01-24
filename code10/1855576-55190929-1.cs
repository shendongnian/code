    public async Task<int> UpdateAsync<T>(T entity, params Expression<Func<T, object>>[] navigations) where T : BaseEntity
    {
    	var dbEntity = await _dbContext.FindAsync<T>(entity.Id);
    
    	var dbEntry = _dbContext.Entry(dbEntity);
    	dbEntry.CurrentValues.SetValues(entity);
    
    	foreach (var property in navigations)
    	{
    		var propertyName = property.GetPropertyAccess().Name;
    		var dbItemsEntry = dbEntry.Collection(propertyName);
    		var accessor = dbItemsEntry.Metadata.GetCollectionAccessor();
    
    		await dbItemsEntry.LoadAsync();
    		var dbItemsMap = ((IEnumerable<BaseEntity>)dbItemsEntry.CurrentValue)
    			.ToDictionary(e => e.Id);
    
    		var items = (IEnumerable<BaseEntity>)accessor.GetOrCreate(entity);
    
    		foreach (var item in items)
    		{
    			if (!dbItemsMap.TryGetValue(item.Id, out var oldItem))
    				accessor.Add(dbEntity, item);
    			else
    			{
    				_dbContext.Entry(oldItem).CurrentValues.SetValues(item);
    				dbItemsMap.Remove(item.Id);
    			}
    		}
    
    		foreach (var oldItem in dbItemsMap.Values)
    			accessor.Remove(dbEntity, oldItem);
    	}
    
    	return await _dbContext.SaveChangesAsync();
    }
