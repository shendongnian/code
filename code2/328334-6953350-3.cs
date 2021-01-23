    public void UpdateGlobalExport(GlobalExport instance)
    {
        var entity = context.Entry(instance);
        entity.State = EntityState.Modified;        
        context.SaveChanges();
    }
