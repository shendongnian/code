    public class LogicalOrRequirement : IAuthorizationRequirement
    {
        public IList<AuthorizationPolicy> Policies { get; }
        public LogicalOrRequirement(IList<AuthorizationPolicy> policies)
        {
            this.Policies = policies;
        }
    }
