    public static class MyLinqExtensions
    {
        public static IQueryable<T> OfTypeOnly<T>(this IQueryable<T> query)
        {
            Type type = typeof (T);
            IEnumerable<Type> derivedTypes = Assembly
                .GetAssembly(type)
                .GetTypes()
                .Where(t => t.IsSubclassOf(type));
            
            return query.ExceptTypes(derivedTypes.ToArray());
        }
    
        public static IQueryable<T> ExceptTypes<T>(this IQueryable<T> query, params Type[] excludedTypes)
        {
            if (excludedTypes == null)
                return query;
    
            return excludedTypes.Aggregate(query,
                (current, excludedType) => current.Where(entity => entity.GetType() != excludedType));
        }
    }
