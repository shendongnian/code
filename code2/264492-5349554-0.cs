    public Boolean Change<TEntity>(TEntity entity)  where TEntity : EntityObject
    {
        // Loads object from DB only if not loaded yet
        ctx.GetObjectByKey(entity.EntityKey);  
        ctx.ApplyCurrentValues​​<T>(entity.GetType().Name, entity);
        ctx.SaveChanges();
    }
