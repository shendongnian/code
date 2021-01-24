	if (rule.Field.StartsWith("ix_"))
	{
		var tokens = rule.Field.Split("_");
		var infoParameter = Expression.Parameter(typeof(UserInformation), "i");
		var infoCondition = Expression.AndAlso(
			Expression.Equal(
				Expression.Property(infoParameter, nameof(UserInformation.Id)),
				Expression.Constant(long.Parse(tokens[1]))),
			BuildCondition(rule, Expression.Property(infoParameter, tokens[2])));
		return Expression.Call(
			typeof(Enumerable), nameof(Enumerable.Any), new[] { infoParameter.Type },
			Expression.Property(pe, nameof(User.Informations)),
			Expression.Lambda(infoCondition, infoParameter));
	}
