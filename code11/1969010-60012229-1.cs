    public static class ExpressionExt {
        public static Expression Simplify(this Expression e) => (new SimplifyVisitor()).Visit(e);
        public static string SimplifiedString(this LambdaExpression e) => e.Body.Simplify().ToString();
    }
    
    public class SimplifyVisitor : ExpressionVisitor {
        protected override Expression VisitMember(MemberExpression node) {
            if (node.Expression is ConstantExpression)
                return Expression.Constant(Expression.Lambda<Func<object>>(Expression.Convert(node, typeof(object))).Compile().Invoke(), node.Type);
            else
                return node;
        }
    }
