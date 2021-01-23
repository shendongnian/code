    public static bool MethodHasAuthorizeAttribute(this Delegate pMethod, string pRoleAccess)
    {
    	var mi = pMethod.GetMethodInfo();
    	const bool includeInherited = false;
    	var atr = mi.GetCustomAttributes(typeof(AuthorizeAttribute), includeInherited)
    				.Select(t => (AuthorizeAttribute)t)
    				.Where(t => pRoleAccess.Length>0?t.Roles == pRoleAccess:true);
    	if (pRoleAccess == String.Empty)
    	{
    		return !atr.Any();
    	}
    	else
    	{
    		return atr.Any();
    	}
    }
    
    public static bool MethodHasAllowAnonymousAttribute(this Delegate pMethod)
    {
    	var mi = pMethod.GetMethodInfo();
    	const bool includeInherited = false;
    	var atr = mi.GetCustomAttributes(typeof(AllowAnonymousAttribute), includeInherited);
    	return atr.Any();
    }
