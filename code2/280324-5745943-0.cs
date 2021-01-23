    public static TOutput SafeEvaluate<TInput, TOutput>
            (this TInput input, Expression<Func<TInput, TOutput>> selector)
    {
        if (selector == null)
            throw new ArgumentNullException("selector");
    
        if (input == null)
            return default(TOutput);
    
        return EvaluateIteratively<TOutput>
                (input, GetSubExpressionStack(selector));
    }
    
    private static T EvaluateIteratively<T>
            (object rootObject, IEnumerable<MemberExpression> expressions)
    {
        object currentObject = rootObject;
    
        foreach (var memEx in expressions)
        {
            var modifiedMemEx = Expression.MakeMemberAccess
                                (Expression.Constant(currentObject), memEx.Member);
            var method = Expression.Lambda(modifiedMemEx).Compile();
            currentObject = method.DynamicInvoke();   
            if (currentObject == null)
                return default(T);
        }
    
        return (T)currentObject;
    }
    
    private static Stack<MemberExpression> GetSubExpressionStack<TInput, TOutput>
            (Expression<Func<TInput, TOutput>> selector)
    {
        var stack = new Stack<MemberExpression>();
    
        var parameter = selector.Parameters.Single();
        var currentSubEx = selector.Body;
    
        while (currentSubEx != parameter)
        {
            var memEx = currentSubEx as MemberExpression;
    
            if (memEx != null)
            {
                stack.Push(memEx);
                currentSubEx = memEx.Expression;
            }
    
            else if (currentSubEx != parameter)
            {
                throw new ArgumentException
                          ("Expression not of the expected form.", "selector");
            }
        }
    
        return stack;
    }
  
