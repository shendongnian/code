    public Expression<Func<TContainer,bool>> CreatePredicate<TContainer,TMember>(
        Expression<Func<TContainer,TMember>> getMemberExpression, 
        Expression<Func<TMember,bool>> memberPredicateExpression)
    {
        return CombineExpressionVisitor.Combine(
            getMemberExpression,
            memberPredicateExpression);
    }
    
    class CombineExpressionVisitor : ExpressionVisitor
    {
        private readonly ParameterExpression _parameterToReplace;
        private readonly Expression _replacementExpression;
        private CombineExpressionVisitor(ParameterExpression parameterToReplace, Expression replacementExpression)
        {
            _parameterToReplace = parameterToReplace;
            _replacementExpression = replacementExpression;
        }
        
        public static Expression<Func<TSource, TResult>> Combine<TSource, TMember, TResult>(
            Expression<Func<TSource, TMember>> memberSelector,
            Expression<Func<TMember, TResult>> resultSelector)
        {
             var visitor = new CombineExpressionVisitor(
                resultSelector.Parameters[0],
                memberSelector.Body);
            return Expression.Lambda<Func<TSource, TResult>>(
                visitor.Visit(resultSelector.Body),
                memberSelector.Parameters);
        }
    
        protected override Expression VisitParameter(ParameterExpression parameter)
        {
            if (parameter == _parameterToReplace)
                return _replacementExpression;
            return base.VisitParameter(parameter);
        }
    }
