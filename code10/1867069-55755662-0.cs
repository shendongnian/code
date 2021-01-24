    public static IQueryable<T> OrderBy<T>(this IQueryable<T> source, 
                                           string property,
                                           bool asc = true) where T : class
    {
        //STEP 1: Validate MORE!
        var searchProperty = typeof(T).GetProperty(property);
        if (searchProperty == null) throw new ArgumentException("property");
        
         ....
      
        //STEP 2: Create the OrderBy property selector
        var parameter = Expression.Parameter(typeof(T), "o");
        var selectorExpr = Expression.Lambda(Expression.Property(parameter, property), parameter)        
    
        //STEP 3: Update the IQueryable expression to include OrderBy
        Expression queryExpr = source.Expression;
        queryExpr = Expression.Call(typeof(Queryable), asc ? "OrderBy" : "OrderByDescending",
                                      new Type[] { source.ElementType, searchProperty.PropertyType },
                                     queryExpr, 
                                    selectorExpr);
    
        return source.Provider.CreateQuery<T>(queryExpr);
    }
