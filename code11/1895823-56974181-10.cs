    public class RoleResourceService : IRoleResourceService
    {
        readonly IConfiguration _config;
        readonly IHttpContextAccessor _accessor;
        readonly UserManager<AppUser> _userManager;
        
        public class RoleResourceService(IConfiguration c, IHttpContextAccessor a, UserManager<AppUser> u) 
        {
            _config = c;
            _accessor = a;
            _userManager = u;
        }
        public bool IsAuthorize(string area, string controller, string action, string id)
        {
            var roleConfig = _config.GetValue<string>($"RoleSetting:{area}:{controller}:{action}"); //assuming we have the setting in appsettings.json
            var appUser = await _userManager.GetUserAsync(_accessor.HttpContext.User);
            var userRoles = await _userManager.GetRolesAsync(appUser);
            // all of needed data are available now, do the logic of authorization
            return result;
        } 
    }
