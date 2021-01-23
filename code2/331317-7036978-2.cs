    public class MyRouteConstraint : IRouteConstraint
        {
            public bool Match(HttpContextBase httpContext, Route route, string parameterName, RouteValueDictionary values, RouteDirection routeDirection)
            {
    
                var action = values["action"] as string;
                var controller = values["controller"] as string;
    
                var controllerFullName = string.Format("MvcApplication1.Controllers.{0}Controller", controller);
    
                var cont = Assembly.GetExecutingAssembly().GetType(controllerFullName);
    
                return cont != null && cont.GetMethod(action) != null;
            }
        }
