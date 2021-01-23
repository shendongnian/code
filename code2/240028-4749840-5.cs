        /// <summary>
        /// Extension methods for the Uri class
        /// </summary>
        public static class UriExtensions
        {
            /// <summary>
            /// Indicates whether the supplied url matches the specified controller and action values based on the MVC routing table defined in global.asax.
            /// </summary>
            /// <param name="uri">A Uri object containing the url to evaluate</param>
            /// <param name="controllerName">The name of the controller class to match</param>
            /// <param name="actionName">The name of the action method to match</param>
            /// <returns>True if the supplied url is mapped to the supplied controller class and action method, false otherwise.</returns>
            public static bool IsRouteMatch(this Uri uri, string controllerName, string actionName)
            {
                RouteInfo routeInfo = new RouteInfo(uri, HttpContext.Current.Request.ApplicationPath);
                return (routeInfo.RouteData.Values["controller"].ToString() == controllerName && routeInfo.RouteData.Values["action"].ToString() == actionName);
            }
        }
