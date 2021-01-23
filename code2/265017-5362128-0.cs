    public Expression<Func<TContainer,bool>> CreatePredicate<TContainer,TMember>(
        Expression<Func<TContainer,TMember>> getMemberExpression, 
        Expression<Func<TMember,bool>> memberPredicateExpression)
    {
        ParameterExpression x = Expression.Parameter(typeof(TContainer), "x");
        return Expression.Lambda<Func<TContainer, bool>>(
            Expression.Invoke(
                memberPredicateExpression,
                Expression.Invoke(
                    getMemberExpression,
                    x)),
            x);
    }
