    public class NotNoneConstraint : IRouteConstraint
    {
        public bool Match(HttpContextBase httpContext, Route route, 
            string parameterName, RouteValueDictionary values, 
            RouteDirection routeDirection)
        {
            return values.ContainsKey(parameterName) &&
                   values[parameterName] != "NONE";
        }
    }
