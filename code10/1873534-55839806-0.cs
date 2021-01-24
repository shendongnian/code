csharp
public static IQueryable<T> Where<T>(this IQueryable<T> that, object notNull, Expression<Func<T, bool>> predicate)
{
    if (!string.IsNullOrWhiteSpace(notNull?.ToString()))
    {
        return that.Where(predicate);
    }
    return that;
}
Then you can compose your LINQ query like this:
csharp
return s.Query()
    .Where(onlyStatus, p => p.Status == onlyStatus)
    .OrderByDescending(p => p.CreatedDate)
    .ToList();
