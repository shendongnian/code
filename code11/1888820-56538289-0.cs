    public class IpAddressWhitelistHandler : AuthorizationHandler<IpAddressWhitelistRequirement>
    {
        private readonly IHttpContextAccessor _httpAccessor;
    
        public IpAddressWhitelistHandler(IHttpContextAccessor httpAccessor)
        {
            _httpAccessor = httpAccessor;
        }
    
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, IpAddressWhitelistRequirement requirement)
        {
            var remoteIp = _httpAccessor.HttpContext.Connection.RemoteIpAddress;
            if (IsIpValid(remoteIp, requirement))
            {
                context.Succeed(requirement);
            }
    
            else
            {
                if (IsAuthenticated(context.User))
                {
                    context.Succeed(requirement);
                }
                else
                {
                    context.Fail();
                }
            }
    
            return Task.CompletedTask;
    
        }
    
        private bool IsIpValid(IPAddress ipAddress, IpAddressWhitelistRequirement requirement)
        {
            bool validIp = false;
    
            var bytes = ipAddress.GetAddressBytes();
    
            var safeIp = IPAddress.Parse(requirement.IpAddress);
            if (safeIp.GetAddressBytes().SequenceEqual(bytes))
            {
                validIp = true;
            }
    
            return validIp;
        }
    
        private bool IsAuthenticated(ClaimsPrincipal user)
        {
            var userIsAnonymous = user?.Identity == null || !user.Identities.Any(i => i.IsAuthenticated);
    
            return !userIsAnonymous;
    
        }
    }
    
    public class IpAddressWhitelistRequirement : IAuthorizationRequirement
    {
        public string IpAddress { get; set; }
    }
