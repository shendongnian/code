    public static IEnumerable<T> RetrieveMultiple<T>(this IOrganizationService service, QueryBase query) where T : Entity
    {
        return service.RetrieveMultiple(query)
            .Entities
            .Select(item => item.ToEntity<T>());
    }
