	public static bool MethodHasAuthorizeAttribute( Expression<System.Action> expression )
	{
		var method = MethodOf( expression );
			
		const bool includeInherited = false;
		return method.GetCustomAttributes( typeof( AuthorizeAttribute ), includeInherited ).Any();
	}
