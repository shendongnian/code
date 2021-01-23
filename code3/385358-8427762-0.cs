    private void AttachSingleEntity<TEntity>(Entity singleEntity, TEntity Tentity)
    {       
        ObjectSet<TEntity> objectSet = context.CreateObjectSet<TEntity>();
        objectSet.Attach(singleEntity);
    }
