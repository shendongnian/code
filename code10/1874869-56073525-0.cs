public IQueryable<TEntity> GetBySpecification(ISpecification<TEntity> spec = null, bool tracking = true, params Func<IQueryable<TEntity>, IQueryable<TEntity>>[] includes)
{
    var query = _context.Set<TEntity>().AsQueryable();
    if (!tracking)
        query = query.AsNoTracking();
    if (includes != null)
        foreach (var include in includes)
            query = include(query);
    if (spec != null)
        query = query.Where(spec.Expression);
    return query;
}
return GetBySpecification(
    includes: new Func<IQueryable<User>, IQueryable<User>>[]
    {
        (q) => q.Include(u => u.Roles).ThenInclude(r => r.Permissions),
    });
