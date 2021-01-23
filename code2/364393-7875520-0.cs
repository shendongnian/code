    public class IsOptionalOrMatchesRegEx : IRouteConstraint
    {
        private readonly string _regEx;
        public IsOptionalOrMatchesRegEx(string regEx)
        {
            _regEx = regEx;
        }
        public bool Match(HttpContextBase httpContext, Route route, string parameterName, RouteValueDictionary values, RouteDirection routeDirection)
        {
            var valueToCompare = values[parameterName].ToString();
            if (string.IsNullOrEmpty(valueToCompare)) return true;
            return Regex.IsMatch(valueToCompare, _regEx);
        }
    }
