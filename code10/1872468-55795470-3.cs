		var eventsToRetrieve = new Dictionary<Guid, long>()
		{
			{ Guid.NewGuid() ,3},
			{ Guid.NewGuid() ,4}
		};
		
		var parameterExpression = Expression.Parameter(typeof(Event));
		Expression idExpression = Expression.Property(parameterExpression, nameof(Event.Id));
		
		var body = 
			eventsToRetrieve.Aggregate(null, (Expression expression, KeyValuePair<Guid,long> etr) => 
		
			{
				var addedExpression = 		 
									Expression.AndAlso(
									Expression.Equal(Expression.Property(idExpression, nameof(EventId.EntityId)), Expression.Constant(etr.Key)),
									Expression.LessThanOrEqual(Expression.Property(idExpression, nameof(EventId.SequenceNumber)), Expression.Constant(etr.Value)));
				return expression != null ? Expression.OrElse(expression,addedExpression) : addedExpression;
			});
		
		
		var filter = (Expression<Func<Event,bool>>) Expression.Lambda(body, parameterExpression);
