          var orderBy = Expression.Call(
                typeof(Queryable),
                "OrderBy",
                new Type[] { query.ElementType, query.ElementType },
                query.Expression,
                criteria.OrderBy);
          var sortedQuery = query.Provider.CreateQuery<T>(orderBy
