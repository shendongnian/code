    public class UserHelper
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public UserHelper(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        public IIdentity GetUserId()
        {
            var userIdentity = _httpContextAccessor.HttpContext?.User.Identity;
           return userIdentity;
        }
    }
