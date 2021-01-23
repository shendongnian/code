    private void AttachSingleEntity<TEntity>(Entity singleEntity) where TEntity:class
    {       
        ObjectSet<TEntity> objectSet = context.CreateObjectSet<TEntity>();
        objectSet.Attach(singleEntity);
    }
