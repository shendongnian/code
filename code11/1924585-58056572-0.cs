csharp
using System;
using System.Linq;
using System.Linq.Expressions;
namespace QueryTest
{
    internal static class Program
    {
        private class ReplaceConstantVisitor : ExpressionVisitor
        {
            public object OldValue { get; }
            public object NewValue { get; }
            public ReplaceConstantVisitor(object oldValue, object newValue)
            {
                OldValue = oldValue;
                NewValue = newValue;
            }
            protected override Expression VisitConstant(ConstantExpression node)
            {
                if (node.Value == OldValue)
                {
                    return Expression.Constant(NewValue);
                }
                return base.VisitConstant(node);
            }
        }
        public static IQueryable<TQuery> ReplaceSource<TQuery, TSource>(this IQueryable<TQuery> query, IQueryable<TSource> source)
        {
            var exp = query.Expression;
            while (exp is MethodCallExpression m)
            {
                exp = m.Arguments[0];
            }
            if (!(exp is ConstantExpression oldSource))
            {
                throw new ArgumentException();
            }
            var newExp = new ReplaceConstantVisitor(oldSource.Value, source).Visit(query.Expression);
            return source.Provider.CreateQuery<TQuery>(newExp);
        }
        internal static void Main(string[] args)
        {
            var oldSource = new int[] { }.AsQueryable();
            var query =
                from i in oldSource
                where i > 5
                select $"{i * 2}";
            var newSource = new int[] { 1, 3, 5, 7, 9 }.AsQueryable();
            var newQuery = query.ReplaceSource(newSource);
            Console.WriteLine(string.Join(", ", newQuery));  //14, 18
        }
    }
}
