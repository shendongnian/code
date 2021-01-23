public sealed class ConstantValueExtractor : ExpressionVisitor
{
    public static object ExtractFirstConstant(Expression expression)
    {
        var visitor = new ConstantValueExtractor();
        visitor.Visit(expression);
        return visitor.ConstantValue;
    }
    private ConstantValueExtractor()
    {
    }
    private object ConstantValue
    {
        get;
        set;
    }
    #region ExpressionVisitor Members
    public override Expression Visit(Expression node)
    {
        this.pathToValue.Push(node);
        var result = base.Visit(node);
        this.pathToValue.Pop();
        return result;
    }
    protected override Expression VisitConstant(ConstantExpression node)
    {
        // The first expression in the path is a ConstantExpression node itself, so just skip it.
        var parentExpression = this.pathToValue.FirstOrDefault(
            expression => expression.NodeType == ExpressionType.MemberAccess);
        if (parentExpression != null)
        {
            // You might get notable performance overhead here, so consider caching
            // compiled lambda or use other to extract the value.
            var valueProviderExpression = Expression.Lambda<Func<object>>(
                Expression.Convert(parentExpression, typeof(object)));
            var valueProvider = valueProviderExpression.Compile();
            this.ConstantValue = valueProvider();
        }
        return base.VisitConstant(node);
    }
    #endregion
    #region private fields
    private Stack<Expression> pathToValue = new Stack<Expression>();
    #endregion
}
class Test
{
    static void Main()
    {
        string name = "Michael";
        Expression<Func<Person, object>> exp = p => p.FirstName == name;
        var value = ConstantValueExtractor.ExtractFirstConstant(exp);
        Console.WriteLine(value);
    }
}
