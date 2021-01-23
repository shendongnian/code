    public class IsUserActionConstraint : IRouteConstraint
    {
        //This is a static variable that handles the list of users
        private static List<string> _users;
        //This constructor loads the list of users on the first call
        public IsUserActionConstraint()
        {
            _users= (from u in Models.Users.Get() select u.Username.ToLower()).ToList();
        }
        //Code for checking to see if the route is a username
        public bool Match(HttpContextBase httpContext, Route route, string parameterName, RouteValueDictionary values, RouteDirection routeDirection)
        {
            return _users.Contains((values["username"] as string).ToLower());
        }
    }
