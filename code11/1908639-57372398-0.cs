     public class UlongRouteConstraint: IRouteConstraint
    {
        public static string UlongRouteConstraintName = "UlongConstraint";
        public bool Match(HttpContext httpContext, IRouter route, string routeKey, RouteValueDictionary values, RouteDirection routeDirection)
        {
            object dateValue;
            if (values.TryGetValue("id", out dateValue))
            {
                ulong date;
                if (UInt64.TryParse(dateValue.ToString(), out date))
                {
                    return true;
                }
            }
            return false;
        }
    }
