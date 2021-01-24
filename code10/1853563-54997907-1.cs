    public IEnumerable<TEntity> GetAll(TKey fKey)
    {
        using (var context = new DbContext())
        {
            IQueryable<TEntity> query = context.Set<TEntity>();
           
            if (fKey != null)
            {
                query = query.Where(e => e.fKey == fKey);
            }
            
            return query.ToList();
        }
    }
