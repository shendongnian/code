 c#
using System;
using System.Linq.Expressions;
static class P
{
    static void Main()
    {
        // the compiler-generated expression-tree from the question
        Console.WriteLine(Baseline(42));
        // build our own epression trees manually
        Console.WriteLine(ByName(42, nameof(Foo.Id)));
        Console.WriteLine(ByName(42, nameof(Foo.ConverterId)));
        // take the compiler-generated expression tree, and rewrite it with a visitor
        Console.WriteLine(Convert(Baseline(42), nameof(Foo.Id), nameof(Foo.ConverterId)));
    }
    static Expression<Func<Foo, bool>> Baseline(int converterId)
    {
        // note this uses a "captured variable", so the output
        // looks uglier than you might expect
        return x => x.Id == converterId;
    }
    static Expression<Func<Foo, bool>> ByName(int converterId, string propertyOrFieldName)
    {
        var p = Expression.Parameter(typeof(Foo), "x");
        var body = Expression.Equal(
            Expression.PropertyOrField(p, propertyOrFieldName),
            Expression.Constant(converterId, typeof(int))
            );
        return Expression.Lambda<Func<Foo, bool>>(body, p);
    }
    static Expression<Func<Foo, bool>> Convert(
        Expression<Func<Foo, bool>> lambda, string from, string to)
    {
        var visitor = new ConversionVisitor(from, to);
        return (Expression<Func<Foo, bool>>)visitor.Visit(lambda);
    }
    class ConversionVisitor : ExpressionVisitor
    {
        private readonly string _from, _to;
        public ConversionVisitor(string from, string to)
        {
            _from = from;
            _to = to;
        }
        protected override Expression VisitMember(MemberExpression node)
        {
            if(node.Member.Name == _from)
            {
                return Expression.PropertyOrField(
                    node.Expression, _to);
            }
            return base.VisitMember(node);
        }
    }
}
class Foo
{
    public int Id { get; set; }
    public int ConverterId { get; set; }
}
