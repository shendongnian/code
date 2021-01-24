    	var eventsToRetrieve = new Dictionary<int, int>()
		{
			{ 1 ,3},
			{ 2 ,4}
		};
		
		var parameterExpression = Expression.Parameter(typeof(Event));
		
		var body = 
			eventsToRetrieve.Aggregate(null, (Expression expression, KeyValuePair<int,int> etr) => 
			{
				var addedExpression = 
									   
									Expression.AndAlso(
									Expression.Equal(Expression.Property(parameterExpression, nameof(Event.Id)), Expression.Constant(etr.Key)),
									Expression.LessThanOrEqual(Expression.Property(parameterExpression, nameof(Event.Seq)), Expression.Constant(etr.Value)));
				return expression != null ? Expression.OrElse(expression,addedExpression) : addedExpression;
			});
		
		
		var filter = Expression.Lambda(body, parameterExpression);
