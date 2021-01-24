    static Action<double> GetSetterForX(Expression<Func<double>> expression)
    {
    	var parameter = Expression.Parameter(typeof(double), "value");
    	var body = Expression.Assign(expression.Body, parameter);
    	var lambda = Expression.Lambda<Action<double>>(body, parameter);
    	return lambda.Compile();
    }
