    public static Expression<Func<TElement, bool>> TestCleanString<TElement>(Expression<Func<TElement, string>> stringSelector, Expression<Func<string, bool>> conditionalExpression)
    {
        //declare the parameter: e =>
        var param = new[] { Expression.Parameter(typeof(TElement), "e") };
        //pass the parameter into the selector to get the string property
        var invokedStringSelector = Expression.Invoke(stringSelector, param.Cast<Expression>());
        //pass the string property to the clean expression
        var invokedCleanString = Expression.Invoke(CleanString(), invokedStringSelector.Expand());
        //pass the cleaned string to the conditional expression
        var invokedConditionalExpression = Expression.Invoke(conditionalExpression, invokedCleanString.Expand());
        //rebuild the expression tree so the provider can understand it
        return Expression.Lambda<Func<TElement, bool>>(invokedConditionalExpression.Expand(), param);
    }
