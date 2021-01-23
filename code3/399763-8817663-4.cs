	public static bool MethodHasAuthorizeAttribute( Expression<System.Action> expression )
	{
		MemberInfo member = MethodOf( expression );
		return MemberHasAuthorizeAttribute( member );
	}
	public static bool TypeHasAuthorizeAttribute( Type t)
	{
		return MemberHasAuthorizeAttribute( t );
	}
	private static bool MemberHasAuthorizeAttribute( MemberInfo member )
	{
		const bool includeInherited = false;
		return member.GetCustomAttributes( typeof( AuthorizeAttribute ), includeInherited ).Any();
	}
