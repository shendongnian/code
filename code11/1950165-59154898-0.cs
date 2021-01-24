    public void Update(T entity)
        {
            DbSet.Attach(entity);
            ApplicationContext.Entry(entity).State = EntityState.Modified;
        }
