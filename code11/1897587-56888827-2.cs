    public virtual async Task<List<TEntity>> GetGamesAsync(
            Expression<Func<TEntity, bool>> where)
        {
            return await dbSet.Where(where).ToListAsync();
        }
