        static IQueryable<IGrouping<T, T>> GroupEntitiesBy<T>(this IQueryable<T> source, string[] fields)
        {
            var itemType = typeof(T);
            var method = typeof(Queryable).GetMethods()
                         .Where(m => m.Name == "GroupBy")
                         .Single(m => m.GetParameters().Length == 2)
                         .MakeGenericMethod(itemType, itemType);
            var result = method.Invoke(null, new object[] { source, source.Select(fields) });
            return (IQueryable<IGrouping<T, T>>)result;
        }
