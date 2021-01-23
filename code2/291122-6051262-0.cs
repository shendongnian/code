    public Boolean Exists(T entity) {
        var objContext = ((IObjectContextAdapter)this.DbContext).ObjectContext;
        var objSet = objContext.CreateObjectSet<T>();
        var entityKey = objContext.CreateEntityKey(objSet.EntitySet.Name, entity);
        Object foundEntity;
        var exists = objContext.TryGetObjectByKey(entityKey, out foundEntity);
        // TryGetObjectByKey attaches a found entity
        // Detach it here to prevent side-effects
        if (exists) {
            objContext.Detach(foundEntity);
        }
        return (exists);
    }
    public void Save(T entity) {
        if (this.Exists(entity)) {
            this.DbSet.Attach(entity);
        }
        else {
            this.DbSet.Add(entity);
        }
        this.DbContext.SaveChanges();
    }
