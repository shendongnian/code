    public sealed class RoleValidator : Attribute, IAuthorizationFilter
	{
		private readonly IEnumerable<string> _roles;
		public RoleValidator(params string[] roles) => _roles = roles;
		public RoleValidator(string role) => _roles = new List<string> { role };
		public void OnAuthorization(AuthorizationFilterContext filterContext)
		{
			if (filterContext.HttpContext.User.Claims == null || filterContext.HttpContext.User.Claims?.Count() <= 0)
			{
				filterContext.Result = new UnauthorizedResult();
				return;
			}
			if (CheckUserRoles(filterContext.HttpContext.User.Claims))
				return;
			filterContext.Result = new ForbidResult();
		}
		private bool CheckUserRoles(IEnumerable<Claim> claims) =>
			JsonConvert.DeserializeObject<List<RoleDto>>(claims.FirstOrDefault(x => x.Type.Equals(ClaimType.Roles.ToString()))?.Value)
				.Any(x => _roles.Contains(x.Name));
	}
