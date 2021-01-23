	public override void OnActionExecuting(ActionExecutingContext filterContext)
	{
		bool hasAuthorizeAttribute = filterContext.ActionDescriptor
			.GetCustomAttributes(typeof(AuthorizeAttribute), false)
			.Any();
		if (hasAuthorizeAttribute)
		{ 
			// do stuff
		}
		base.OnActionExecuting(filterContext);
	}
