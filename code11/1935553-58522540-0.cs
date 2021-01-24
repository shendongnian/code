    public class HeaderRequirement : IAuthorizationRequirement
    {
        public HeaderRequirement(string header)
        {
            Header = header;
        }
        public string Header { get; }
    }
    public class HeaderRequirementHandler : AuthorizationHandler<HeaderRequirement>
    {
        protected override Task HeaderRequirementHandler (
            AuthorizationHandlerContext context,
            HeaderRequirement requirement)
        {
            var hasHeader = context.Request.Headers.ContainsKey(requirement.Header);
            if (hasHeader) // if we have the header
            {
                context.Succeed(requirement); // authorization successful
            }
            return Task.CompletedTask;
        }
    }
