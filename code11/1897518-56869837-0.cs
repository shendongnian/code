 c#
public virtual IQueryable<TEntity> GetManyQueryable(
    Expression<Func<TEntity, bool>> where)
{
    return dbSet.Where(where);
}
Then you should be able to use:
var query = whatever.Where(
    g => g.productCode == initiate.productCode && g.referenceId == null).ToListAsync();
but to be honest... that isn't much different to what you already have
