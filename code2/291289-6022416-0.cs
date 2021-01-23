    public void Detach(object entity)
    {
        var objectContext = ((IObjectContextAdapter)this).ObjectContext;
        objectContext.Detach(entity);
    }
