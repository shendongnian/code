        [AttributeUsage(AttributeTargets.All, Inherited = false, AllowMultiple = true)]
    public class GroupsAttribute : TypeFilterAttribute
    {
        public GroupsAttribute(string groups) : base(typeof(ClaimRequirementFilter))
        {
            Arguments = new object[] { groups };
        }
    }
    public class ClaimRequirementFilter : IAuthorizationFilter
    {
        readonly string _groups;
        public ClaimRequirementFilter(string groups)
        {
            _groups = groups;
        }
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var groups = _groups.Split(',');
            bool hasClaim = false;
            foreach (var group in groups)
            {
                if (context.HttpContext.User.Claims.Any(c => c.Type == ClaimTypes.GroupSid && c.Value.Equals(group.Trim(), StringComparison.OrdinalIgnoreCase)))
                    hasClaim = true;
            }
            if (!hasClaim)
            {
                context.Result = new ForbidResult();
            }
        }
    }
