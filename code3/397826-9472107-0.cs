    class Program
    {
        static void Main(string[] args)
        {
            Expression<Func<DateTime, double>> abc = v => 1.0d * v.Ticks / (v.Month + v.Minute);
            MyExpressionVisitor mev = new MyExpressionVisitor(DateTime.Now);
            var ret = mev.Visit(abc);
        }
    }
    internal class MyExpressionVisitor : ExpressionVisitor
    {
        IEnumerable<ParameterExpression> _parameters = null;
        object _parameterValue = null;
        public MyExpressionVisitor(object valueOfParameter)
        {
            _parameterValue = valueOfParameter;
        }
        protected override Expression VisitLambda<T>(Expression<T> node)
        {
            _parameters = node.Parameters;
            return base.VisitLambda<T>(node);
        }
        protected override Expression VisitBinary(BinaryExpression node)
        {
            if (_parameters != null)
            {
                // Evaluate right node.
                var value = EvaluateExpression(node.Right, _parameters.ToArray(), _parameterValue);
                // substitute value with 2 * value.
                var newRight = Expression.Constant(value * 2);
                var ret = node.Update(node.Left, node.Conversion, newRight);
                return ret;
            }
            return base.VisitBinary(node);
        }
        protected double EvaluateExpression(Expression expression, ParameterExpression[] parameters, object parameterValue)
        {
            var lambda = Expression.Lambda(expression, parameters);
            var compiled = lambda.Compile();
            var value = compiled.DynamicInvoke(parameterValue);
            return Convert.ToDouble(value);
        }
    }
