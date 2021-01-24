    public static Expression<Func<T, IEnumerable<TChild>>> Combine<T, TChild>
    (
      Expression<Func<T, IEnumerable<TChild>>> navigationProperty,
      Expression<Func<TChild, bool>> filter
    )
      where T : class
      where TChild : class, IDeletable
    {
        // Consider caching the MethodInfo object: 
        var whereMethodInfo = GetEnumerableWhereMethodInfo<TChild>();
    
        // Produce an Expression tree like:
        // Enumerable.Where(<navigationProperty>, <filter>)
        var filterExpr = Expression
            .Call(
                whereMethodInfo,
                navigationProperty.Body,
                filter
            );
        
        // Create a Lambda Expression with the parameters
        // used for `navigationProperty` expression
        return Expression
            .Lambda<Func<T, IEnumerable<TChild>>>(
                filterExpr,
                navigationProperty.Parameters
            );
    }
    
    private static MethodInfo GetEnumerableWhereMethodInfo<TSource>()
    {
        // Get a MethodInfo definition for `Enumerable.Where<>`:
        var methodInfoDefinition = typeof(Enumerable)
           .GetMethods()
           .Where(x => x.Name == nameof(Enumerable.Where))
           .First(x =>
           {
               var parameters = x.GetParameters();
    
               return
                   parameters.Length == 2 &&
                   parameters[0].ParameterType.GetGenericTypeDefinition() == typeof(IEnumerable<>) &&
                   parameters[1].ParameterType.GetGenericTypeDefinition() == typeof(Func<,>);
           });
    
        // Get a MethodInfo object for `Enumerable.Where<TSource>`:
        var methodInfo = methodInfoDefinition.MakeGenericMethod(typeof(TSource));
        
        return methodInfo;
    }
