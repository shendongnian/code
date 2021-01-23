    public void InsertOrUpdate<T>(T entity, DbContext db) where T : class
    {
        if (db.Entry(entity).State == EntityState.Detached)
            db.Set<T>().Add(entity);
        // If an immediate save is needed, can be slow though
        // if iterating through many entities:
        db.SaveChanges(); 
    }
