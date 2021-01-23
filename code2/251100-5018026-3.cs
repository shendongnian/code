    public class PluralConstraint : IRouteConstraint
        {
            public bool Match(HttpContextBase httpContext, Route route, string parameterName, RouteValueDictionary values, RouteDirection routeDirection)
            {
                List<string> names = GetControllerNames();//get all controller names from executing assembly
                names.ForEach(n => n.Pluralize(n));
                return names.Contains(values[parameterName]);
            }
        }
