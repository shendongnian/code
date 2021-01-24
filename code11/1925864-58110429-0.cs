        public class GrpcRequireemnt : IAuthorizationRequirement
        { 
        
        }
        public class GrpcHandler : AuthorizationHandler<GrpcRequireemnt>
        {
            private readonly IHttpContextAccessor _httpContextAccessor;
            public GrpcHandler(IHttpContextAccessor httpContextAccessor)
            {
                _httpContextAccessor = httpContextAccessor;
            }
            protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, GrpcRequireemnt requirement)
            {
                var headers = _httpContextAccessor.HttpContext.Request.Headers;
                StringValues token;
                if (!headers.TryGetValue("token", out token))
                {
                    context.Fail();
                    return Task.CompletedTask;
                }
                context.Succeed(requirement);
                return Task.CompletedTask;
            }
        }
