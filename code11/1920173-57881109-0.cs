csharp
public static bool Any<TEntity, TProperty>(this IEnumerable<TEntity> source, Func<TEntity, TProperty> selector, TEntity other)
{
    if (source is null)
        throw new ArgumentNullException(nameof(source));
    if (selector is null)
        throw new ArgumentNullException(nameof(selector));
    if (other == null)
        throw new ArgumentNullException(nameof(other));
    TProperty otherProperty = selector(other);
    return source.Any(item => EqualityComparer<TProperty>.Default.Equals(selector(item), otherProperty));
}
Now, that'll work on objects in memory, but since you have the [tag:entity-framework-core] tag, we'll need something that deals with expressions.
csharp
public static bool Any<TEntity, TProperty>(this IQueryable<TEntity> source, Expression<Func<TEntity, TProperty>> selectorExpression, TEntity other)
{
    if (source is null)
        throw new ArgumentNullException(nameof(source));
    if (selectorExpression is null)
        throw new ArgumentNullException(nameof(selectorExpression));
    if (other == null)
        throw new ArgumentNullException(nameof(other));
    ParameterExpression itemParameter = selectorExpression.Parameters[0];
    ConstantExpression otherValue = Expression.Constant(selectorExpression.Compile()(other), typeof(TProperty));
    BinaryExpression equalExpression = Expression.Equal(Expression.Invoke(selectorExpression, itemParameter), otherValue);
    Expression<Func<TEntity, bool>> predicate = Expression.Lambda<Func<TEntity, bool>>(equalExpression, itemParameter);
    return source.Any(predicate);
}
In my own testing, using SQL Profile to confirm, I was able to get the condition to evaluate in the SQL query.  After changing the property selection expression, the query changed accordingly.
