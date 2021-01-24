    public class UserResourceRequirement : IAuthorizationRequirement
    {
        public async Task<bool> Pass(IHttpContextAccessor contextAccessor, AppUser user, string area, string controller, string action, string id)
        {
            //authorization logic goes here
            return result;
        }
    }
