    public class VersionConstraint : IActionConstraint
    {
        private readonly IEnumerable<string> allowedValues;
        public VersionConstraint(IEnumerable<string> allowedValues)
        {
            this.allowedValues = allowedValues;
        }
        public int Order => 0;
        public bool Accept(ActionConstraintContext ctx)
        {
            if (!ctx.RouteContext.RouteData.Values.TryGetValue("version", out var routeVersion))
                return false;
            return allowedValues.Contains((string)routeVersion);
        }
    }
