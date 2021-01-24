    static Expression<T> Compose<T>(Expression<T> first, Expression<T> second, Func<Expression, Expression, Expression> merge)
    {
        // zip parameters (map from parameters of second to parameters of first)    
        var map = first.Parameters
            .Select((f, i) => new { f, s = second.Parameters[i] })
            .ToDictionary(p => p.s, p => p.f);
        // replace parameters in the second lambda expression with the parameters in the first    
        var secondBody = ParameterRebinder.ReplaceParameters(map, second.Body);
        // create a merged lambda expression with parameters from the first expression    
        return Expression.Lambda<T>(merge(first.Body, secondBody), first.Parameters);
    }
    
    class ParameterRebinder : ExpressionVisitor {
        readonly Dictionary<ParameterExpression, ParameterExpression> map;
        ParameterRebinder(Dictionary<ParameterExpression, ParameterExpression> map)
        {
            this.map = map ?? new Dictionary<ParameterExpression, ParameterExpression>();
        }
        public static Expression ReplaceParameters(Dictionary<ParameterExpression, ParameterExpression> map, Expression exp)
        {
            return new ParameterRebinder(map).Visit(exp);
        }
        protected override Expression VisitParameter(ParameterExpression p)
        {
            ParameterExpression replacement;
            if (map.TryGetValue(p, out replacement))
            {
                p = replacement;
            }
            return base.VisitParameter(p);
        }
    }
