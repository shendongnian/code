    public static class AutomapperExtensions
    {
        public static IMappingExpression<TSource, TDestination> ForTwoMembers<TSource, TDestination, TMember>(this IMappingExpression<TSource, TDestination>  mappingExpression, Expression<Func<TDestination, TMember>> destinationMember1, Expression<Func<TDestination, TMember>> destinationMember2, Action<IMemberConfigurationExpression<TSource, TDestination, TMember>> memberOptions)
        {
            return mappingExpression
                .ForMember(destinationMember1, memberOptions)
                .ForMember(destinationMember2, memberOptions);
        }
    }
