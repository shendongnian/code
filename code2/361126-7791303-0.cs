    protected MyEntities sqlEntities;
    public virtual void Delete(TEntity entity)
    {
        sqlEntities.Attach(entity);
        sqlEntities.DeleteObject(entity);
        sqlEntities.SaveChanges();
    }
