	protected override void HandleUnauthorizedRequest(AuthorizationContext context)
	{
		if (context.HttpContext.Request.IsAuthenticated)
		{
			// Returns HTTP 403 - see comment in HttpForbiddenResult.cs.
			filterContext.Result = new HttpForbiddenResult("Forbidden Access.");
		}
		else
		{
			base.HandleUnauthorizedRequest(context);
		}
	}
