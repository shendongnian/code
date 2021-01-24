        public class DateRouteConstraint : IRouteConstraint
        {
            public static string DateRouteConstraintName = "DateRouteConstraint";
            public bool Match(HttpContext httpContext, IRouter route, string routeKey, RouteValueDictionary values, RouteDirection routeDirection)
            {
                object dateValue;
                if (values.TryGetValue("date", out dateValue))
                {
                    DateTime date;
                    string[] formats = { "yyyy-MM-dd" };
                    if (DateTime.TryParseExact(dateValue.ToString(), formats,
                                    CultureInfo.InvariantCulture,
                                    DateTimeStyles.None, out date))
                    {
                        
                        return true;
                    }
                }
                return false;
            }
        }
