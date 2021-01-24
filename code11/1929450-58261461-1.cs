internal class SubstExpressionVisitor : ExpressionVisitor
{
    private readonly Dictionary<Expression, Expression> _subst = new Dictionary<Expression, Expression>();
    protected override Expression VisitParameter(ParameterExpression node)
    {
        if (_subst.TryGetValue(node, out Expression newValue))
        {
            return newValue;
        }
        return node;
    }
    public Expression this[Expression original]
    {
        get => _subst[original];
        set => _subst[original] = value;
    }
}
public static class PredicateBuilder
{
    // you don't seem to need this but it's included for completeness sake
    public static Expression<Predicate<T>> And<T>(this Expression<Predicate<T>> a, Expression<Predicate<T>> b)
    {
        if (a == null)
            throw new ArgumentNullException(nameof(a));
        if (b == null)
            throw new ArgumentNullException(nameof(b));
        ParameterExpression p = a.Parameters[0];
        SubstExpressionVisitor visitor = new SubstExpressionVisitor();
        visitor[b.Parameters[0]] = p;
        Expression body = Expression.AndAlso(a.Body, visitor.Visit(b.Body));
        return Expression.Lambda<Predicate<T>>(body, p);
    }
    public static Expression<Predicate<T>> Or<T>(this Expression<Predicate<T>> a, Expression<Predicate<T>> b)
    {
        if (a == null)
            throw new ArgumentNullException(nameof(a));
        if (b == null)
            throw new ArgumentNullException(nameof(b));
        ParameterExpression p = a.Parameters[0];
        SubstExpressionVisitor visitor = new SubstExpressionVisitor();
        visitor[b.Parameters[0]] = p;
        Expression body = Expression.OrElse(a.Body, visitor.Visit(b.Body));
        return Expression.Lambda<Predicate<T>>(body, p);
    }
}
You can use it like this: 
Expression<Predicate<Item>> func1 = (x1) => x1.Color == "Black";
Expression<Predicate<Item>> func2 = (x2) => x2.Categories.Any(y => categories.Select(z => z == y).Any());
Expression<Predicate<Item>> finalExpr = func1.Or(func2);
You might want to keep in mind that my `Or` is using `OrElse` internally so the second expression won't be evaluated if the one before is evaluated to true (`OrElse` is like `||`, not `|`). The same goes for `And` with `AndAlso` (`AndAlso` is like `&&`, not `&`).  
Another thing to note is that you can easily replace `Predicate<T>` with `Func<T, bool>` if you have to use `Func` for some reason :)
