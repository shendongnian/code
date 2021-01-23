    public static IEnumerable<T> FunkyOrder<T>(this IEnumerable<T> input, string fieldname = "Id", string sortdirection = "asc")
    {
     ParameterExpresssion parameter = Expression.Parameter(typeof(T), "p");
     Expression property = Expression.PropertyOrField(parameter, fieldname);
     
     **EDIT**
     Type lambdaType = typeof(Func<,>).MakeGenericType(typeof(T), property.Type)
     var lambda = Expression.Lambda(lambdaType, property, parameter)
     
     if(sortdirection == "asc")
     {
      return input.OrderBy(lambda);
     }
     else
     {
      return input.OrderByDescending(lambda);
     }
    }
