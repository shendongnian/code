    public void Remove(int id)
    {
        TEntity obj = new TEntity() { Id = id };
        dbContext.Entry(obj).State = EntityState.Deleted;
    }
