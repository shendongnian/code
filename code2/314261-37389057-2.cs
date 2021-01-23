    public static IMappingExpression<TSource, TDestination> FlattenNested<TSource, TNestedSource, TDestination>(
        this IMappingExpression<TSource, TDestination> expression,
        Expression<Func<TSource, TNestedSource>> nestedSelector,
        IMappingExpression<TNestedSource, TDestination> nestedMappingExpression)
    {
        var dstProperties = typeof(TDestination).GetProperties().Select(p => p.Name);
    
        var flattenedMappings = nestedMappingExpression.TypeMap.GetPropertyMaps()
                                                        .Where(pm => pm.IsMapped() && !pm.IsIgnored())
                                                        .ToDictionary(pm => pm.DestinationProperty.Name,
                                                                        pm => Expression.Lambda(
                                                                            Expression.MakeMemberAccess(nestedSelector.Body, pm.SourceMember),
                                                                            nestedSelector.Parameters[0]));
    
        foreach (var property in dstProperties)
        {
            if (!flattenedMappings.ContainsKey(property))
                continue;
    
            expression.ForMember(property, opt => opt.MapFrom((dynamic)flattenedMappings[property]));
        }
    
        return expression;
    }
