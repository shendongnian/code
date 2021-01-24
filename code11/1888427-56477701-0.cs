    public async Task<IList<TEntity>> GetAsync(Func<IQueryable<TEntity>, IQueryable<TEntity>> 
    getFunction)
    {
        if (getFunction == null)
        {
            return new List<TEntity>();
        }
        return await getFunction(_dbSet).AsNoTracking().ToListAsync();
    }
