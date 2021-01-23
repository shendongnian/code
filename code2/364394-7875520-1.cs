    public class ExcludeConstraint : IRouteConstraint
    {
        private readonly List<string> _excludedList;
        public ExcludeConstraint(List<string> excludedList)
        {
            _excludedList = excludedList;
        }
        public bool Match(HttpContextBase httpContext, Route route, string parameterName, RouteValueDictionary values, RouteDirection routeDirection)
        {
            var valueToCompare = (string)values[parameterName];
            return _excludedList.Contains(valueToCompare);            
        }
    }
