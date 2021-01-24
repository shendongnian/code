    public class HttpUserContext
    {
        private readonly IHttpContextAccessor _contextAccessor;
        public HttpUserContext(IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
        }
        public SomeClassContainingUserData GetCurrentUser()
        {
            var httpContext = _contextAccessor.HttpContext;
            // get the user data from the context and return it.
        }
    }
