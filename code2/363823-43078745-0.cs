    static class IQueryableExtensions
     {
         public static IQueryable<T> OrderBy<T>(this IQueryable<T> items, string propertyName)
         {
             var typeOfT = typeof(T);
             var parameter = Expression.Parameter(typeOfT, "parameter");
             var propertyType = typeOfT.GetProperty(propertyName).PropertyType;
             var propertyAccess = Expression.PropertyOrField(parameter, propertyName);
             var orderExpression = Expression.Lambda(propertyAccess, parameter);
     
             var expression = Expression.Call(typeof(Queryable), "OrderBy", new Type[] { typeOfT, propertyType }, items.Expression, Expression.Quote(orderExpression));
             return items.Provider.CreateQuery<T>(expression);
         }
     
         public static IQueryable<T> OrderByDescending<T>(this IQueryable<T> items, string propertyName)
         {
             var typeOfT = typeof(T);
             var parameter = Expression.Parameter(typeOfT, "parameter");
             var propertyType = typeOfT.GetProperty(propertyName).PropertyType;
             var propertyAccess = Expression.PropertyOrField(parameter, propertyName);
             var orderExpression = Expression.Lambda(propertyAccess, parameter);
     
             var expression = Expression.Call(typeof(Queryable), "OrderByDescending", new Type[] { typeOfT, propertyType }, items.Expression, Expression.Quote(orderExpression));
             return items.Provider.CreateQuery<T>(expression);
         }
     
         public static IQueryable<T> ThenBy<T>(this IQueryable<T> items, string propertyName)
         {
             var typeOfT = typeof(T);
             var parameter = Expression.Parameter(typeOfT, "parameter");
             var propertyType = typeOfT.GetProperty(propertyName).PropertyType;
             var propertyAccess = Expression.PropertyOrField(parameter, propertyName);
             var orderExpression = Expression.Lambda(propertyAccess, parameter);
     
             var expression = Expression.Call(typeof(Queryable), "ThenBy", new Type[] { typeOfT, propertyType }, items.Expression, Expression.Quote(orderExpression));
             return items.Provider.CreateQuery<T>(expression);
         }
     
         public static IQueryable<T> ThenByDescending<T>(this IQueryable<T> items, string propertyName)
         {
             var typeOfT = typeof(T);
             var parameter = Expression.Parameter(typeOfT, "parameter");
             var propertyType = typeOfT.GetProperty(propertyName).PropertyType;
             var propertyAccess = Expression.PropertyOrField(parameter, propertyName);
             var orderExpression = Expression.Lambda(propertyAccess, parameter);
     
             var expression = Expression.Call(typeof(Queryable), "ThenByDescending", new Type[] { typeOfT, propertyType }, items.Expression, Expression.Quote(orderExpression));
             return items.Provider.CreateQuery<T>(expression);
         }
     }
