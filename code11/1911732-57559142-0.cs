    public static IQueryable<TDestination> ProjectTo<TSource, TDestination>(
        this IQueryable<TSource> query,
        TSource sourceTypeInstance,
        TDestination destinationTypeInstance,
        IConfigurationProvider configuration)
    {
        var projectToMethod = typeof(AutoMapper.QueryableExtensions.Extensions)
                .GetMethod("ProjectTo", new Type[]
                {
                    typeof(IQueryable),
                    typeof(IConfigurationProvider),
                    typeof(IDictionary<string, object>),
                    typeof(string[])
                })
                .MakeGenericMethod(typeof(TDestination));
        return projectToMethod.Invoke(query, new object[] { query, configuration, new Dictionary<string, object>(), new string[] { } });
    }
