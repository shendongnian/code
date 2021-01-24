        public class UserIdentityAccessor
        {
            private readonly RequestDelegate _next;
    
            public UserIdentityAccessor(RequestDelegate next)
            {
                _next = next;
            }
    
            public async Task InvokeAsync(HttpContext context, IUserIdentity userIdentity)
            {
                var user = (ClaimsIdentity) context.User.Identity;
                
                if (user.IsAuthenticated)
                {
                    var first = user.FindFirst(ClaimsName.FirstName).Value; \\ get info from claims
                    userIdentity.FirstName = first;                         \\ and add to identity
                }
                else
                {
                    userIdentity.FirstName = null;
                }
    
                await _next(context);
            }
        }
    
