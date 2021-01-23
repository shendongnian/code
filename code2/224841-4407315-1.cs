    public class IsLocalRouteConstraint :  IRouteConstraint
    {
      public bool Match(HttpContextBase context, Route route,  string paramName, RouteValueDictionary dict, RouteDirection direction
      {
        return context.Request.IsLocal;
      }
    }
