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
             currentValues.SetValues(entity);
    	 
         foreach (var properteyName  in currentValues.PropertyNames)//make default false value for all 
            {
             Repository.GetDbContext().Entry(existedEntity).Property(properteyName).IsModified = false;
            }
    	 
    	 
         foreach (var name in properities)
         {
             Repository.GetDbContext().Entry(existedEntity).Property(name).IsModified = true; //put true for only properities that we want to update
         }
         Repository.GetDbContext().SaveChanges();
         return await Task.FromResult(existedEntity);
    
      }
   
