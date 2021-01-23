    public class NotEqualToAreaName : IRouteConstraint
    {
       public bool Match(HttpContextBase httpContext, Route route, string parameterName, RouteValueDictionary values, RouteDirection routeDirection)
       {
          return String.Compare(values[parameterName].ToString(), route.DataTokens["area"].ToString(), true) != 0;
       }    
    }
