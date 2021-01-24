    using System;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Reflection;
    public static class MyExtensions
    {
        /// <summary>
        /// Helper method to reflect the return type.
        /// </summary>
        public static Expression<Func<T1, TResult>> FuncX<T1, TResult>(Expression<Func<T1, TResult>> lambda)
            => lambda;
        /// <summary>
        /// Helper method to get a <see cref="MemberInfo"/>.
        /// </summary>
        public static MemberInfo GetMember<TSource, TResult>(this Expression<Func<TSource, TResult>> lambda)
            => (lambda?.Body as MemberExpression)?.Member ?? throw new ArgumentException($"Not a {nameof(MemberExpression)}.");
        /// <summary>
        /// Helper method to get a <see cref="MethodInfo"/>.
        /// </summary>
        public static MethodInfo GetMethod<TSource, TResult>(this Expression<Func<TSource, TResult>> lambda)
            => (lambda?.Body as MethodCallExpression)?.Method ?? throw new ArgumentException($"Not a {nameof(MethodCallExpression)}.");
        /// <summary>
        /// <see cref="Queryable.OrderBy{TSource,TKey}(System.Linq.IQueryable{TSource},System.Linq.Expressions.Expression{System.Func{TSource,TKey}})"/>
        /// </summary>
        private static readonly MethodInfo _miOrderBy = GetMethod((IQueryable<int> q) => q.OrderBy(x => x)).GetGenericMethodDefinition();
        /// <summary>
        /// Replace occurrencies of OrderBy(<paramref name="oriKeySelector"/>) with OrderBy(<paramref name="newKeySelector"/>).
        /// </summary>
        /// <exception cref="ArgumentException"><paramref name="oriKeySelector"/>'s body is not a <see cref="MemberExpression"/>.</exception>
        public static IQueryable<TQueryable> ChangeOrder<TQueryable, TOrdered, TOrigOrder, TNewOrder>(this IQueryable<TQueryable> queryable, Expression<Func<TOrdered, TOrigOrder>> oriKeySelector, Expression<Func<TOrdered, TNewOrder>> newKeySelector)
        {
            var changed = new ChangeOrderVisitor<TOrdered, TOrigOrder, TNewOrder>(oriKeySelector, newKeySelector).Visit(queryable.Expression);
            return queryable.Provider.CreateQuery<TQueryable>(changed);
        }
        private sealed class ChangeOrderVisitor<TOrdered, TOrigOrder, TNewOrder> : ExpressionVisitor
        {
            private static readonly MethodInfo _miOrigOrderBy = _miOrderBy.MakeGenericMethod(typeof(TOrdered), typeof(TOrigOrder));
            private static readonly MethodInfo _miNewOrderBy = _miOrderBy.MakeGenericMethod(typeof(TOrdered), typeof(TNewOrder));
            private readonly MemberInfo _origMember;
            private readonly Expression<Func<TOrdered, TNewOrder>> _newKeySelector;
            public ChangeOrderVisitor(Expression<Func<TOrdered, TOrigOrder>> origKeySelector, Expression<Func<TOrdered, TNewOrder>> newKeySelector)
            {
                _origMember = origKeySelector.GetMember();
                _newKeySelector = newKeySelector;
            }
            protected override Expression VisitMethodCall(MethodCallExpression node)
            {
                if (node.Method == _miOrigOrderBy)
                {
                    if (node.Arguments[1] is UnaryExpression u &&
                        u.Operand is LambdaExpression lambda &&
                        lambda.Body is MemberExpression mx &&
                        mx.Member == _origMember)
                        return Expression.Call(_miNewOrderBy, Visit(node.Arguments[0]), _newKeySelector);
                }
                return base.VisitMethodCall(node);
            }
        }
    }
