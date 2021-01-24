    public class DynamicAuthorizationFilter : IAsyncAuthorizationFilter
    {
        private readonly ApplicationDbContext _dbContext;
    
        public DynamicAuthorizationFilter(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
    
        public async Task OnAuthorizationAsync(AuthorizationFilterContext context)
        {
            if (!IsProtectedAction(context))
                return;
    
            if (!IsUserAuthenticated(context))
            {
                context.Result = new UnauthorizedResult();
                return;
            }
    
            var actionId = GetActionId(context);
            var userName = context.HttpContext.User.Identity.Name;
    
            var roles = await (
                from user in _dbContext.Users
                join userRole in _dbContext.UserRoles on user.Id equals userRole.UserId
                join role in _dbContext.Roles on userRole.RoleId equals role.Id
                where user.UserName == userName
                select role
            ).ToListAsync();
    
            foreach (var role in roles)
            {
                var accessList = JsonConvert.DeserializeObject<IEnumerable<MvcControllerInfo>>(role.Access);
                if (accessList.SelectMany(c => c.Actions).Any(a => a.Id == actionId))
                    return;
            }
    
            context.Result = new ForbidResult();
        }
