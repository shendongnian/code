    public static class ExpressionExt {
        // Compose: (y => f(y)).Compose(x => g(x)) -> x => f(g(x))
        /// <summary>
        /// Composes two LambdaExpression into a new LambdaExpression
        /// </summary>
        /// <param name="Tpg">Type of parameter to gFn, and type of parameter to result lambda.</param>
        /// <param name="Tpf">Type of result of gFn and type of parameter to fFn.</param>
        /// <param name="TRes">Type of result of fFn and type of result of result lambda.</param>
        /// <param name="fFn">The outer LambdaExpression.</param>
        /// <param name="gFn">The inner LambdaExpression.</param>
        /// <returns>LambdaExpression representing outer composed with inner</returns>
        public static Expression<Func<Tpg, TRes>> Compose<Tpg, Tpf, TRes>(this Expression<Func<Tpf, TRes>> fFn, Expression<Func<Tpg, Tpf>> gFn) =>
            Expression.Lambda<Func<Tpg, TRes>>(fFn.Body.Replace(fFn.Parameters[0], gFn.Body), gFn.Parameters[0]);
    
        /// <summary>
        /// Replaces an Expression (reference Equals) with another Expression
        /// </summary>
        /// <param name="orig">The original Expression.</param>
        /// <param name="from">The from Expression.</param>
        /// <param name="to">The to Expression.</param>
        /// <returns>Expression with all occurrences of from replaced with to</returns>
        public static Expression Replace(this Expression orig, Expression from, Expression to) => new ReplaceVisitor(from, to).Visit(orig);
    }
    
    /// <summary>
    /// ExpressionVisitor to replace an Expression (that is Equals) with another Expression.
    /// </summary>
    public class ReplaceVisitor : ExpressionVisitor {
        readonly Expression from;
        readonly Expression to;
    
        public ReplaceVisitor(Expression from, Expression to) {
            this.from = from;
            this.to = to;
        }
    
        public override Expression Visit(Expression node) => node == from ? to : base.Visit(node);
    }
