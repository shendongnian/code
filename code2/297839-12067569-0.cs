    public class ConverterExpressionVisitor<TDest> : ExpressionVisitor
    {
        protected override Expression VisitLambda<T>(Expression<T> node)
        {
            var readOnlyCollection = node.Parameters.Select(a => Expression.Parameter(typeof(TDest), a.Name));
            return Expression.Lambda(node.Body, node.Name, readOnlyCollection);
        }
    
        protected override Expression VisitParameter(ParameterExpression node)
        {
            return Expression.Parameter(typeof(TDest), node.Name);
        }
    }
    
    public class A { public string S { get; set; } }
    public class B : A { }
    
    static void Main(string[] args)
    {
        Expression<Func<A, bool>> ExpForA = a => a.S.StartsWith("Foo");
        Console.WriteLine(ExpForA); // a => a.S.StartsWith("Foo");
    
        var converter = new ConverterExpressionVisitor<B>();
        Expression<Func<B, bool>> ExpForB = (Expression<Func<B, bool>>)converter.Visit(ExpForA);
        Console.WriteLine(ExpForB); // a => a.S.StartsWith("Foo"); - same as for A but for B
        Console.ReadLine();
    }
