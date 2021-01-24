    [AttributeUsage(AttributeTargets.Class)]
    public class MyAuthorize : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var dbContext = context.HttpContext.RequestServices.GetRequiredService<ApplicationDbContext>();
            var roles = dbContext.Roles.ToList();
            foreach (var role in roles)
            {
                if (!context.HttpContext.User.IsInRole(role.Name))
                {
                    context.Result = new ForbidResult();
                }
            }
        }
    }
