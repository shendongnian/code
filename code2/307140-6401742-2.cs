    static void Main(string[] args)
    {
        var source = new List<int> { 1, 2, 3 };
        var any = new List<Expression<Func<int, bool>>>();
        any.Add(x => x == 1);
        any.Add(x => x == 3);
        foreach (var item in source.AsQueryable().WhereDisjunction(any))
        {
            Console.WriteLine(item);
        }
    }
    class RewriteSingleParameterUsage : ExpressionVisitor
    {
        public ParameterExpression Parameter { get; set; }
        protected override Expression VisitParameter(ParameterExpression node)
        {
            return Parameter;
        }
    }
    public static IQueryable<T> WhereDisjunction<T>(this IQueryable<T> source, IList<Expression<Func<T, bool>>> any)
    {
        switch (any.Count)
        {
            case 0: return source;
            case 1: return source.Where(any[0]);
            default:
                var p = Expression.Parameter(any[0].Parameters[0].Type, any[0].Parameters[0].Name);
                var rw = new RewriteSingleParameterUsage { Parameter = p };
                var expr = rw.Visit(any[0].Body);
                for (int i = 1; i < any.Count; i++)
                {
                    expr = Expression.Or(expr, rw.Visit(any[i].Body));
                }
                return source.Where(Expression.Lambda<Func<T, bool>>(expr, p));
        }
    }
