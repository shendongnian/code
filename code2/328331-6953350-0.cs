    public void UpdateGlobalExport(GlobalExport instance)
    {
        var entity = context.Entry(instance);
    
        if (entity.State == EntityState.Detached)
        {
            context.Set<TEntity>().Attach(instance);
            entity.State = EntityState.Modified;
        }
        
        context.SaveChanges();
    }
