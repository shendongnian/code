    public class Reflector
    {
        public static string GetPropertyName<T>(Expression<Func<T, object>> expression)
        {
            var lambdaEx = expression as LambdaExpression;
            if (lambdaEx == null) throw new ArgumentNullException("expression");
            MemberExpression memberExpression = null;
            if (lambdaEx.Body.NodeType == ExpressionType.Convert)
            {
                var unaryExpression = lambdaEx.Body as UnaryExpression;
                if (unaryExpression == null) throw new ArgumentNullException("expression");
                if (unaryExpression.Operand.NodeType == ExpressionType.MemberAccess)
                {
                    memberExpression = unaryExpression.Operand as MemberExpression;
                }
            }
            else if (lambdaEx.Body.NodeType == ExpressionType.MemberAccess)
            {
                memberExpression = lambdaEx.Body as MemberExpression;
            }
            if (memberExpression == null) throw new ArgumentNullException("expression");
                return memberExpression.Member.Name;
        }
    }
