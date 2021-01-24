    public class DelegateByLambda: ExpressionVisitor
    {
        LambdaExpression delegateReferenceExpression;
        LambdaExpression lambdaExpression;
        Stack<InvocationExpression> invocations;
        public DelegateByLambda(LambdaExpression delegateReferenceExpression, LambdaExpression lambdaExpression)
        {
            this.delegateReferenceExpression = delegateReferenceExpression;
            this.lambdaExpression = lambdaExpression;
            this.invocations = new Stack<InvocationExpression>();
        }
    
        protected override Expression VisitParameter(ParameterExpression node)
        {
            var paramIndex = lambdaExpression.Parameters.IndexOf(node);
            if (paramIndex >= 0)
            {
                InvocationExpression call = invocations.Peek();
                return base.Visit(call.Arguments[paramIndex]);
            }
            return base.VisitParameter(node);
        }
        protected override Expression VisitInvocation(InvocationExpression node)
        {
            if (node.Expression.ToString() == delegateReferenceExpression.Body.ToString())
            {
                invocations.Push(node);
                var result = base.Visit(lambdaExpression.Body);
                invocations.Pop();
                return result;
            }
            return base.VisitInvocation(node);
        }
    }
