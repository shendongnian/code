    public static class Ext {
        private static Expression<Func<TP, TC, TResult>> CastSMBody<TP, TC, TResult>(LambdaExpression ex, TP unusedP, TC unusedC, TResult unusedRes) => (Expression<Func<TP, TC, TResult>>)ex;
    
        public static IQueryable<TResult> LeftOuterJoin<TLeft, TRight, TKey, TResult>(
            this IQueryable<TLeft> leftItems,
            IQueryable<TRight> rightItems,
            Expression<Func<TLeft, TKey>> leftKeySelector,
            Expression<Func<TRight, TKey>> rightKeySelector,
            Expression<Func<TLeft, TRight, TResult>> resultSelector) where TLeft : class where TRight : class where TResult : class {
    
            // (lrg,r) => resultSelector(lrg.left, r)
            var sampleAnonLR = new { left = (TLeft)null, rightg = (IEnumerable<TRight>)null };
            var parmP = Expression.Parameter(sampleAnonLR.GetType(), "lrg");
            var parmC = Expression.Parameter(typeof(TRight), "r");
            var argLeft = Expression.PropertyOrField(parmP, "left");
            var newleftrs = CastSMBody(Expression.Lambda(resultSelector.Apply(argLeft, parmC), new[] { parmP, parmC }), sampleAnonLR, (TRight)null, (TResult)null);
    
            return leftItems.GroupJoin(rightItems, leftKeySelector, rightKeySelector, (left, rightg) => new { left, rightg }).SelectMany(r => r.rightg.DefaultIfEmpty(), newleftrs);
        }
    
        public static IQueryable<TResult> RightOuterJoin<TLeft, TRight, TKey, TResult>(
            this IQueryable<TLeft> leftItems,
            IQueryable<TRight> rightItems,
            Expression<Func<TLeft, TKey>> leftKeySelector,
            Expression<Func<TRight, TKey>> rightKeySelector,
            Expression<Func<TLeft, TRight, TResult>> resultSelector) where TLeft : class where TRight : class where TResult : class {
    
            // (lgr,l) => resultSelector(l, lgr.right)
            var sampleAnonLR = new { leftg = (IEnumerable<TLeft>)null, right = (TRight)null };
            var parmP = Expression.Parameter(sampleAnonLR.GetType(), "lgr");
            var parmC = Expression.Parameter(typeof(TLeft), "l");
            var argRight = Expression.PropertyOrField(parmP, "right");
            var newrightrs = CastSMBody(Expression.Lambda(resultSelector.Apply(parmC, argRight), new[] { parmP, parmC }), sampleAnonLR, (TLeft)null, (TResult)null);
    
            return rightItems.GroupJoin(leftItems, rightKeySelector, leftKeySelector, (right, leftg) => new { leftg, right })
                             .SelectMany(l => l.leftg.DefaultIfEmpty(), newrightrs);
        }
    
        private static Expression<Func<TParm, TResult>> CastSBody<TParm, TResult>(LambdaExpression ex, TParm unusedP, TResult unusedRes) => (Expression<Func<TParm, TResult>>)ex;
    
        public static IQueryable<TResult> RightAntiSemiJoin<TLeft, TRight, TKey, TResult>(
            this IQueryable<TLeft> leftItems,
            IQueryable<TRight> rightItems,
            Expression<Func<TLeft, TKey>> leftKeySelector,
            Expression<Func<TRight, TKey>> rightKeySelector,
            Expression<Func<TLeft, TRight, TResult>> resultSelector) where TLeft : class where TRight : class where TResult : class {
    
            // newrightrs = lgr => resultSelector((TLeft)null, lgr.right)
            var sampleAnonLgR = new { leftg = (IEnumerable<TLeft>)null, right = (TRight)null };
            var parmLgR = Expression.Parameter(sampleAnonLgR.GetType(), "lgr");
            var argLeft = Expression.Constant(null, typeof(TLeft));
            var argRight = Expression.PropertyOrField(parmLgR, "right");
            var newrightrs = CastSBody(Expression.Lambda(resultSelector.Apply(argLeft, argRight), new[] { parmLgR }), sampleAnonLgR, (TResult)null);
    
            return rightItems.GroupJoin(leftItems, rightKeySelector, leftKeySelector, (right, leftg) => new { leftg, right }).Where(lgr => !lgr.leftg.Any()).Select(newrightrs);
        }
    
        public static IQueryable<TResult> FullOuterJoin<TLeft, TRight, TKey, TResult>(
            this IQueryable<TLeft> leftItems,
            IQueryable<TRight> rightItems,
            Expression<Func<TLeft, TKey>> leftKeySelector,
            Expression<Func<TRight, TKey>> rightKeySelector,
            Expression<Func<TLeft, TRight, TResult>> resultSelector) where TLeft : class where TRight : class where TResult : class {
    
            return leftItems.LeftOuterJoin(rightItems, leftKeySelector, rightKeySelector, resultSelector).Concat(leftItems.RightAntiSemiJoin(rightItems, leftKeySelector, rightKeySelector, resultSelector));
        }
    
        public static Expression Apply(this LambdaExpression e, params Expression[] args) {
            var b = e.Body;
    
            foreach (var pa in e.Parameters.Cast<ParameterExpression>().Zip(args, (p, a) => (p, a))) {
                b = b.Swap(pa.p, pa.a);
            }
    
            return b.PropagateNull();
        }
    
        public static Expression Swap(this Expression orig, Expression from, Expression to) => new SwapVisitor(from, to).Visit(orig);
        public class SwapVisitor : System.Linq.Expressions.ExpressionVisitor {
            public readonly Expression from;
            public readonly Expression to;
    
            public SwapVisitor(Expression _from, Expression _to) {
                from = _from;
                to = _to;
            }
    
            public override Expression Visit(Expression node) => node == from ? to : base.Visit(node);
        }
    
        public static Expression PropagateNull(this Expression orig) => new NullVisitor().Visit(orig);
        public class NullVisitor : System.Linq.Expressions.ExpressionVisitor {
            public override Expression Visit(Expression node) {
                if (node is MemberExpression nme && nme.Expression is ConstantExpression nce && nce.Value == null)
                    return Expression.Constant(null, nce.Type.GetMember(nme.Member.Name).Single().GetMemberType());
                else
                    return base.Visit(node);
            }
        }
    
        public static Type GetMemberType(this MemberInfo member) {
            switch (member) {
                case FieldInfo mfi:
                    return mfi.FieldType;
                case PropertyInfo mpi:
                    return mpi.PropertyType;
                case EventInfo mei:
                    return mei.EventHandlerType;
                default:
                    throw new ArgumentException("MemberInfo must be if type FieldInfo, PropertyInfo or EventInfo", nameof(member));
            }
        }
    }
