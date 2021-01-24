    public class UserResourceHandler : AuthorizationHandler<UserResourceRequirement>
    {
        readonly IRoleResourceService _roleResourceService;
    
        public UserResourceHandler (IRoleResourceService r)
        {
            _roleResourceService = r;
        }
    
        protected override async Task HandleRequirementAsync(AuthorizationHandlerContext authHandlerContext, UserResourceRequirement requirement)
        {
            if (context.Resource is AuthorizationFilterContext filterContext)
            {
                var area = (filterContext.RouteData.Values["area"] as string)?.ToLower();
                var controller = (filterContext.RouteData.Values["controller"] as string)?.ToLower();
                var action = (filterContext.RouteData.Values["action"] as string)?.ToLower();
                var id = (filterContext.RouteData.Values["id"] as string)?.ToLower();
                if (_roleResourceService.IsAuthorize(area, controller, action, id))
                {
                    context.Succeed(requirement);
                }               
            }            
        }
    }
