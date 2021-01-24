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
To do that, we must first evaluate the property to get the value against which we'll be comparing each entity's selected property.  In memory, we just call `selector(other)` and we're done.  Since we have to deal with an expression now, we need to compile the expression first.  That's fairly simple.
The next step is to build an expression that represents `selector(item) == otherValue`.  Fortunately, we don't need to replace the parameter since we're not trying to fold two separate lambdas into the same expression.  We can simply reuse `selector`'s first parameter.  We then call `Expression.Invoke` with the selector and its parameter, which will be translated into the column reference in the SQL.
Finally, we build the lambda that we can pass along to the built-in `Any` method.
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
