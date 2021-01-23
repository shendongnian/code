    public class MyConstraint: IRouteConstraint
    {
        public bool Match(HttpContextBase httpContext, Route route, string parameterName, RouteValueDictionary values, RouteDirection routeDirection)
        {
            var value = values[parameterName] as string;
            if (!string.IsNullOrEmpty(value))
            {
                return !value.StartsWith("sampleliteral", StringComparison.OrdinalIgnoreCase);
            }
            return true;
        }
    }
