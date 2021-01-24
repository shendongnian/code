public class ParameterReplaceVisitor : ExpressionVisitor
{
    private readonly ParameterExpression target;
    private readonly ParameterExpression replacement;
    public ParameterReplaceVisitor(ParameterExpression target, ParameterExpression replacement) =>
        (this.target, this.replacement) = (target, replacement);
    protected override Expression VisitParameter(ParameterExpression node)
    {
        return node == target ? replacement : base.VisitParameter(node);
    }
}
Then use this to rewrite your `rightExpression`, so it uses the same parameter as `leftExpression`:
var visitor = new ParameterReplaceVisitor(rightExpression.Parameters[0], leftExpression.Parameters[0]);
var rewrittenRightBody = rightExpression.Body.Visit(visitor);
var andExpression = Expression.AndAlso(leftExpression.Body, rewrittenRightBody );
return Expression.Lambda<Func<T, bool>>(
    andExpression, leftExpression.Parameters[0]);
