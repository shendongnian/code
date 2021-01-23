    public class ControllerFactory : DefaultControllerFactory
    {
        public override IController CreateController(RequestContext requestContext, 
            string controllerName)
        {
            requestContext.RouteData.Values["action"] =
                requestContext.RouteData.Values["action"].ToString().Replace("-", "");
            return base.CreateController(requestContext, controllerName.Replace("-",""));
        }
    }
