    using (var context = new OpenContext<TContext>(connectionString))
    {
    	var repository = context.UnitOfWork.GetRepository<TEntity, TKey>();
    	repository.Update(CurrentItem);
    	
    	// Get the type of TEntity
    	Type typeOfTEntity = typeof(TEntity);
    	foreach (var property in typeOfTEntity.GetProperties())
    	{
    		// Check the properties that are virtual and not are HashSet
    		if (property.GetGetMethod().IsVirtual && property.PropertyType.GenericTypeArguments.Count() == 0)
    		{
    			object value = property.GetValue(CurrentItem);
    			// Check that value is not null and value type is an Entity
    			if (value != null && value.GetType().IsSubclassOf(typeof(Entity<int>)))
    			{
    				// Set the value that I don't want to change
    				context.Context.Entry(value).State = EntityState.Detached;
    			}
    		}
    	}
    	context.UnitOfWork.SaveChanges();
    }
