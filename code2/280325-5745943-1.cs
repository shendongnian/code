    public static TOutput NullSafeEvaluate<TInput, TOutput>
            (this TInput input, Expression<Func<TInput, TOutput>> selector)
    {
        if (selector == null)
            throw new ArgumentNullException("selector");
    
        if (input == null)
            return default(TOutput);
    
        return EvaluateIterativelyOrDefault<TOutput>
                (input, GetSubExpressions(selector));
    }
    
    private static T EvaluateIterativelyOrDefault<T>
            (object rootObject, IEnumerable<MemberExpression> expressions)
    {
        object currentObject = rootObject;
    
        foreach (var sourceMemEx in expressions)
        {
            // Produce next "nested" member-expression. 
            // Reuse the value of the last expression rather than 
            // re-evaluating from scratch.
            var currentEx = Expression.MakeMemberAccess
                          (Expression.Constant(currentObject), sourceMemEx.Member);
    
    
            // Evaluate expression.
            var method = Expression.Lambda(currentEx).Compile();
            currentObject = method.DynamicInvoke();
    
            // Expression evaluates to null, return default.
            if (currentObject == null)
                return default(T);
        }
    
        // All ok.
        return (T)currentObject;
    }
    
    private static IEnumerable<MemberExpression> GetSubExpressions<TInput, TOutput>
            (Expression<Func<TInput, TOutput>> selector)
    {
        var stack = new Stack<MemberExpression>();
    
        var parameter = selector.Parameters.Single();
        var currentSubEx = selector.Body;
    
        // Iterate through the nested expressions, "reversing" their order.
        // Stop when we reach the "root", which must be the sole parameter.
        while (currentSubEx != parameter)
        {
            var memEx = currentSubEx as MemberExpression;
    
            if (memEx != null)
            {
                // Valid member-expression, push. 
                stack.Push(memEx);
                currentSubEx = memEx.Expression;
            }
    
            // It isn't a member-expression, it must be the parameter.
            else if (currentSubEx != parameter)
            {
    
                // No, it isn't. Throw, don't support arbitrary expressions.
                throw new ArgumentException
                            ("Expression not of the expected form.", "selector");
            }
        }
    
        return stack;
    }
  
