`
public IQueryable<T> Get(
    Expression<Func<T, int>> select,
    Expression<Func<T, bool>> where,
    Func<IQueryable<T>, IOrderedQueryable<T>> orderBy)
{
    var databaseSet = this.Context.Set<T>();
    var query = (IQueryable<T>) databaseSet;
    if (filter != null)
    {
        query = query.Where(where);
    }
    if (orderBy != null)
    {
        query = orderBy(query);
    }
    if (select != null)
    {
         query = query.Select(select);
    }
    return query;
}
