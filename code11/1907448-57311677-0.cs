 c#
static Expression<Func<TItem, bool>> Contains<TItem, TProperty>(
    Expression<Func<TItem, TProperty>> accessor,
    IEnumerable<TProperty> allowedValues)
{
    var body = Expression.Call(typeof(Enumerable), nameof(Enumerable.Contains),
        new[] { typeof(TProperty) },
        Expression.Constant(allowedValues, typeof(IEnumerable<TProperty>)),
        accessor.Body);
    return Expression.Lambda<Func<TItem, bool>>(body, accessor.Parameters);
}
You should be able to pass the result of this to `Queryable.Where`.
