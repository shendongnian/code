    public static IEnumerable<T> FunkyOrder<T, TResult>(this IEnumerable<T> input, string fieldname = "Id", string sortdirection = "asc")
    {
     ParameterExpresssion parameter = Expression.Parameter(typeof(T), "p");
     Expression property = Expression.PropertyOrField(parameter, fieldname);
     
     var lambda = Expression.Lambda<Func<T, TResult>>(property, parameter)
     
     if(sortdirection == "asc")
     {
      return input.OrderBy(lambda.Compile());
     }
     else
     {
      return input.OrderByDescending(lambda.Complile());
     }
    }
