cs
public class ProjectionExpressionVisitor : ExpressionVisitor
{
    internal Expression<Func<TSource, TDest>> Optimise<TSource, TDest>(Expression<Func<TSource, TDest>> expression)
    {
        return Visit(expression) as Expression<Func<TSource, TDest>>;
    }
    protected override Expression VisitConditional(ConditionalExpression node)
    {
        var test = ReduceExpression(node.Test);
        // The conditional is now a constant, we can replace the branch
        if (test is ConstantExpression testNode)
        {
            var value = (dynamic) testNode.Value;
            return value ? ReduceExpression(node.IfTrue) : ReduceExpression(node.IfFalse);
        }
        // If it is not a conditional, we follow the default behaviour
        return base.VisitConditional(node);
    }
    public Expression ReduceExpression(Expression node)
    {
        if (node is ConstantExpression)
        {
            // Constants represent the smallest item, so we can just return it
            return node;
        }
        else if (node is MemberExpression memberNode)
        {
            return ReduceMemberExpression(memberNode);
        }
        else if (node is BinaryExpression binaryNode)
        {
            return ReduceBinaryExpression(binaryNode);
        }
        // This is not a supported expression type to reduce, fallback to default
        return node;
    }
    public Expression ReduceMemberExpression(MemberExpression node)
    {
        if (
            node.Expression.NodeType == ExpressionType.Constant ||
            node.Expression.NodeType == ExpressionType.MemberAccess
        )
        {
            var objectMember = Expression.Convert(node, typeof(object));
            var getterLambda = Expression.Lambda<Func<object>>(objectMember);
            var getter = getterLambda.Compile();
            var value = getter();
            return Expression.Constant(value);
        }
        return node;
    }
    public Expression ReduceBinaryExpression(BinaryExpression node)
    {
        var left = ReduceExpression(node.Left);
        var right = ReduceExpression(node.Right);
        var leftConst = left as ConstantExpression;
        var rightConst = right as ConstantExpression;
        // Special optimisations
        var optimised = OptimiseBooleanBinaryExpression(node.NodeType, leftConst, rightConst);
        if (optimised != null) return Expression.Constant(optimised);
        if (leftConst != null && rightConst != null)
        {
            var leftValue = (dynamic)leftConst.Value;
            var rightValue = (dynamic)rightConst.Value;
            switch (node.NodeType)
            {
                case ExpressionType.Add:
                    return Expression.Constant(leftValue + rightValue);
                case ExpressionType.Divide:
                    return Expression.Constant(leftValue / rightValue);
                case ExpressionType.Modulo:
                    return Expression.Constant(leftValue % rightValue);
                case ExpressionType.Multiply:
                    return Expression.Constant(leftValue * rightValue);
                case ExpressionType.Power:
                    return Expression.Constant(leftValue ^ rightValue);
                case ExpressionType.Subtract:
                    return Expression.Constant(leftValue - rightValue);
                case ExpressionType.And:
                    return Expression.Constant(leftValue & rightValue);
                case ExpressionType.AndAlso:
                    return Expression.Constant(leftValue && rightValue);
                case ExpressionType.Or:
                    return Expression.Constant(leftValue | rightValue);
                case ExpressionType.OrElse:
                    return Expression.Constant(leftValue || rightValue);
                case ExpressionType.Equal:
                    return Expression.Constant(leftValue == rightValue);
                case ExpressionType.NotEqual:
                    return Expression.Constant(leftValue != rightValue);
                case ExpressionType.GreaterThan:
                    return Expression.Constant(leftValue > rightValue);
                case ExpressionType.GreaterThanOrEqual:
                    return Expression.Constant(leftValue >= rightValue);
                case ExpressionType.LessThan:
                    return Expression.Constant(leftValue < rightValue);
                case ExpressionType.LessThanOrEqual:
                    return Expression.Constant(leftValue <= rightValue);
            }
        }
        return node;
    }
    private bool? OptimiseBooleanBinaryExpression(ExpressionType type, ConstantExpression leftConst, ConstantExpression rightConst)
    {
        // This is only a necessary optimisation when only part of the binary expression is constant
        if (leftConst != null && rightConst != null)
            return null;
        var leftValue = (dynamic)leftConst?.Value;
        var rightValue = (dynamic)rightConst?.Value;
        // We can check for constants on each side to simplify the reduction process
        if (
            (type == ExpressionType.And || type == ExpressionType.AndAlso) &&
            (leftValue == false || rightValue == false))
        {
            return false;
        }
        else if (
            (type == ExpressionType.Or || type == ExpressionType.OrElse) &&
            (leftValue == true || rightValue == true))
        {
            return true;
        }
        return null;
    }
}
Fundamentally, the idea is that we optimise conditional expressions through reducing them as much as possible and then apply some special case logic when mixing parameter lambdas.
Usage is as follows
cs
var opts = new UserImplParams
{
    IncludeUserRole = true
};
var projection = UserImpl.Projection(opts);
var expression = new ProjectionExpressionVisitor().Optimise(projection);
await _databaseContext.Users.Select(expression).ToListAsync();
Hopefully this will help someone else with a similar problem.
  [1]: https://dba.stackexchange.com/questions/12941/does-sql-server-read-all-of-a-coalesce-function-even-if-the-first-argument-is-no/12945#12945
