    Expression orderByExtensionMethodExpression = Expression.Call(typeof(QueryableExtensions), "OrderBy", new[] { queryable.ElementType },
    						Expression.Constant(queryable), 
    						Expression.Constant(sorting.ColumnName), 
    						Expression.Constant(sorting.Direction, typeof(string)));
    
    					queryable = Expression.Lambda(orderByExtensionMethodExpression).Compile().DynamicInvoke() as IQueryable;
