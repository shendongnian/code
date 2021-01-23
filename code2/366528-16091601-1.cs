	public string GetSessionID(System.Web.HttpContext context)
	{
		// Never use a session ID from an unauthenticated request...
		if (!context.Request.IsAuthenticated) 
			return null;
		return _originalManager.GetSessionID(context);
	}
