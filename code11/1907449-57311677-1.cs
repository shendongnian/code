 c#
static Expression<Func<TItem, bool>> Contains<TItem, TProperty>(
    Expression<Func<TItem, TProperty>> accessor,
    IEnumerable<TProperty> allowedValues)
{
    var wrapped = new { allowedValues };
    var body = Expression.Call(typeof(Enumerable), nameof(Enumerable.Contains),
        new[] { typeof(TProperty) },
        Expression.PropertyOrField(Expression.Constant(wrapped), nameof(allowedValues)),
        accessor.Body);
    return Expression.Lambda<Func<TItem, bool>>(body, accessor.Parameters);
}
You should be able to pass the result of this to `Queryable.Where`.
Note that `wrapped` here is to add a layer of indirection that the receiving LINQ query parser might want.
