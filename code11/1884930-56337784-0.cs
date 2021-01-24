 c#
static void Main()
{
    Expression<Func<int, int, bool>> before = (x, y) => x * 2 == y + 1;
    var after = ReplaceParameter(before, 3);
    Console.WriteLine(after);
}
public static Expression<Func<TElement, bool>> ReplaceParameter<TElement>
(
    Expression<Func<TElement, TElement, bool>> inputExpression,
    TElement element
)
{
    var replacer = new Replacer(inputExpression.Parameters[0],
        Expression.Constant(element, typeof(TElement)));
    var body = replacer.Visit(inputExpression.Body);
    return Expression.Lambda<Func<TElement, bool>>(body,
        inputExpression.Parameters[1]);
}
class Replacer : ExpressionVisitor
{
    private readonly Expression _from, _to;
    public Replacer(Expression from, Expression to)
    {
        _from = from;
        _to = to;
    }
    public override Expression Visit(Expression node)
        => node == _from ? _to : base.Visit(node);
}
Note that this does not automatically collapse pure constant expressions, i.e. the code shown results in:
 c#
y => ((3 * 2) == (y + 1))
You *could* however, if you wanted, try looking for `BinaryExpression` that only has `ConstantExpression` as inputs, and evaluate the node directly, again inside `Replacer`.
