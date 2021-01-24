    public class ReplaceParameterVisitor : ExpressionVisitor
    {
        public static Expression<Func<TElement, bool>> ReplaceParameter<TElement>(
            Expression<Func<TElement, TElement, bool>> inputExpression, 
            TElement element)
        {
            Expression body = inputExpression.Body;
            ReplaceParameterVisitor visitor = 
                new ReplaceParameterVisitor(inputExpression.Parameters[1], 
                                            Expression.Constant(element));
            Expression newBody = visitor.Visit(body);
            Expression<Func<TElement, bool>> newExpression = 
                Expression.Lambda<Func<TElement, Boolean>>(
                    newBody, 
                    new ParameterExpression[] { inputExpression.Parameters[0] });
            return newExpression;
        }
        private ReplaceParameterVisitor(
            ParameterExpression param, 
            ConstantExpression constant)
        {
            this._param = param;
            this._constant = constant;
        }
        private readonly ParameterExpression _param;
        private readonly ConstantExpression _constant;
        protected override Expression VisitParameter(ParameterExpression node)
        {
            if (node == this._param)
            {
                return this._constant;
            }
            else
            {
                return base.VisitParameter(node);
            }
        }
    }
