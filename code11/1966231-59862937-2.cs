public static Expression<Func<T, bool>> OrElse<T>(
    this Expression<Func<T, bool>> expr1,
    Expression<Func<T, bool>> expr2)
{
    var parameter = Expression.Parameter(typeof(T));
    var leftVisitor = new ReplaceExpressionVisitor(expr1.Parameters[0], parameter);
    var left = leftVisitor.Visit(expr1.Body);
    var rightVisitor = new ReplaceExpressionVisitor(expr2.Parameters[0], parameter);
    var right = rightVisitor.Visit(expr2.Body);
    return Expression.Lambda<Func<T, bool>>(
        Expression.OrElse(left, right), parameter);
}
private class ReplaceExpressionVisitor
    : ExpressionVisitor
{
    private readonly Expression _oldValue;
    private readonly Expression _newValue;
    public ReplaceExpressionVisitor(Expression oldValue, Expression newValue)
    {
        _oldValue = oldValue;
        _newValue = newValue;
    }
    public override Expression Visit(Expression node)
    {
        if (node == _oldValue)
            return _newValue;
        return base.Visit(node);
    }
}
That lets us write:
Expression<Func<Whatever, bool>> query = t => false;
if (queryObj.AgeCategory.Contains((int)AgeList._0to5))
{
    query = query.OrElse(v => v.BuildYear <= yearNow && v.BuildYear > year5);
}
if (queryObj.AgeCategory.Contains((int)AgeList._6to10))
{
    query = query.OrElse(v => v.BuildYear <= year5 && v.BuildYear > year10);
}
... and so on...
queryRecord = whatever.Where(query);
This generates a single query, which will look like:
WHERE (BuildYear <= yearNow AND BuildYear > year5) OR (BuildYear < year5 AND BuildYear > year10) etc
