public class PropertyAccessVisitor : ExpressionVisitor
{
    public Dictionary<Expression, List<(Expression child, string name)>> ParentsToChildren { get; } = new Dictionary<Expression, List<(Expression child, string name)>>();
    protected override Expression VisitMethodCall(MethodCallExpression node)
    {
        // If it's a call to Select, then we know that it calls its lambda on each of the items in its input
        if (node.Method.Name == "Select" && node.Method.DeclaringType == typeof(Enumerable))
        {
            Add(node.Arguments[0], node.Arguments[1], null);
        }
        return base.VisitMethodCall(node);
    }
    protected override Expression VisitLambda<T>(Expression<T> node)
    {
        foreach (var parameter in node.Parameters)
        {
            Add(node, parameter, null);
        }
        return base.VisitLambda(node);
    }
    protected override Expression VisitMember(MemberExpression node)
    {
        Add(node.Expression, node, node.Member.Name);
        return base.VisitMember(node);
    }
    private void Add(Expression parent, Expression child, string name)
    {
        if (!ParentsToChildren.TryGetValue(parent, out var children))
        {
            children = new List<(Expression child, string name)>();
            ParentsToChildren[parent] = children;
        }
        children.Add((child, name));
    }
}
public static void Main()
{
    Expression<Func<Tab, object>> includeExpressions = x => x.Columns.Select(y => y.Options);
    var visitor = new PropertyAccessVisitor();
    visitor.Visit(includeExpressions);
    var results = new List<string>();
    var stack = new Stack<(Expression expression, string path)>();
    stack.Push((includeExpressions, null));
    while (stack.Count > 0)
    {
        var (expression, path) = stack.Pop();
        if (visitor.ParentsToChildren.TryGetValue(expression, out var children))
        {
            foreach (var child in children)
            {
                stack.Push((child.child, child.name == null ? path : $"{path}.{child.name}"));
            }
        }
        else
        {
            results.Add(path);
        }
    }
}
