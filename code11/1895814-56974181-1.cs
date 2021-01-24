    public class UserResourceHandler : AuthorizationHandler<UserResourceRequirement>
    {
        readonly IHttpContextAccessor _contextAccessor;
        readonly UserManager<AppUser> _usermanager;
    
        public UserResourceHandler (IHttpContextAccessor c, UserManager<AppUser> u)
        {
            _contextAccessor = c;
            _userManager = u;
        }
    
        protected override async Task HandleRequirementAsync(AuthorizationHandlerContext authHandlerContext, UserResourceRequirement requirement)
        {
            var user = _userManager.GetUserAsync(_contextAccessor.HttpContext.User);
            if (context.Resource is AuthorizationFilterContext filterContext)
            {
                var area = (filterContext.RouteData.Values["area"] as string)?.ToLower();
                var controller = (filterContext.RouteData.Values["controller"] as string)?.ToLower();
                var action = (filterContext.RouteData.Values["action"] as string)?.ToLower();
                var id = (filterContext.RouteData.Values["id"] as string)?.ToLower();
                if (await requirement.Pass(_contextAccessor, user, area, controller, action, id))
                {
                    context.Succeed(requirement);
                }
                else
                {
                    context.Fail();
                }
            }
            else
            {
                context.Fail();
            }
        }
    }
