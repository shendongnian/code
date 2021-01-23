	public static IMappingExpression<TSource, TDestination> MapOnlyIfDirty<TSource, TDestination>(
		this IMappingExpression<TSource, TDestination> map)
	{
		map.ForAllMembers(source =>
		{
			source.Condition(resolutionContext =>
			{
				if (resolutionContext.SourceValue == null)
					return !(resolutionContext.DestinationValue == null);
				return !resolutionContext.SourceValue.Equals(resolutionContext.DestinationValue);
			});
		});
		return map;
	}
