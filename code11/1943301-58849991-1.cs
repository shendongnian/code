    public class AuthorizeUserAttribute:AuthorizeAttribute, IAsyncAuthorizationFilter
    {
        public string Action { get; set; }
        public AuthorizeUserAttribute(string action)
        {
            Action = action;       
        }
        public async Task OnAuthorizationAsync(AuthorizationFilterContext authorizationFilterContext)
        {
            var x = authorizationFilterContext.HttpContext.RequestServices.GetRequiredService<IUserRoleService>();
            var y = x.GetValues();
        }
    }
