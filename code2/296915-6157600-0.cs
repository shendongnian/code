    public virtual T GetByKey<T>(int id) where T : class, IEntity
    {
         string containerName = context.DefaultContainerName;
         string setName = context.CreateObjectSet<T>().EntitySet.Name;
         // Build entity key
         var entityKey = new EntityKey(containerName + "." + setName, "Id", key);
         return (TEntity)Context.GetObjectByKey(entityKey);         
    }
