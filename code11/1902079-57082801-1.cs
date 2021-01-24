    public static class ExpressionExt2 {   
        public static Expression PropagateNull(this Expression orig) => new NullVisitor().Visit(orig);
    
        // Apply: (x => f).Apply(args)
        /// <summary>
        /// Substitutes an array of Expression args for the parameters of a lambda, returning a new Expression
        /// </summary>
        /// <param name="e">The original LambdaExpression to "call".</param>
        /// <param name="args">The Expression[] of values to substitute for the parameters of e.</param>
        /// <returns>Expression representing e.Body with args substituted in</returns>
        public static Expression Apply(this LambdaExpression e, params Expression[] args) {
            var b = e.Body;
    
            foreach (var pa in e.Parameters.Zip(args, (p, a) => (p, a)))
                b = b.Replace(pa.p, pa.a);
    
            return b.PropagateNull();
        }
    }
    
    /// <summary>
    /// ExpressionVisitor to replace a null.member Expression with a null
    /// </summary>
    public class NullVisitor : System.Linq.Expressions.ExpressionVisitor {
        public override Expression Visit(Expression node) {
            if (node is MemberExpression nme && nme.Expression is ConstantExpression nce && nce.Value == null)
                return Expression.Constant(null, nce.Type.GetMember(nme.Member.Name).Single().GetMemberType());
            else
                return base.Visit(node);
        }
    }
    
    public static class MeberInfoExt {
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
