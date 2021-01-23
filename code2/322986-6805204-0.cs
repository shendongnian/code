    	[AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
	public class UserIDFilter : ActionFilterAttribute
	{
		public bool Require { get; set; }
		public override void OnActionExecuting(ActionExecutingContext filterContext)
		{
			if (Require)
			{
				if (Membership.GetUser() == null)
				{
					string formsAuthenticationToken = HttpContext.Current.Request.Form["cookie"];
					if (!string.IsNullOrEmpty(formsAuthenticationToken))
					{
						FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(formsAuthenticationToken);
						if (ticket != null)
						{
							FormsIdentity identity = new FormsIdentity(ticket);
							string[] roles = Roles.GetRolesForUser(identity.Name);
							GenericPrincipal principal = new GenericPrincipal(identity, roles);
							HttpContext.Current.User = principal;
						}
					}
					if (Membership.GetUser() == null)
						throw new UserNotAuthenticatedException();
				}
			}
			const string key = "userId";
			if (filterContext.ActionParameters.ContainsKey(key))
			{
				if (Membership.GetUser() != null)
					filterContext.ActionParameters[key] = (Guid)Membership.GetUser().ProviderUserKey;
				else
					filterContext.ActionParameters[key] = (Guid?)null;
			}
			base.OnActionExecuting(filterContext);
		}
	}
