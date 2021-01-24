    public static bool TryGetUserName(this IIdentity identity, out string username)
	{
		try
		{
			username = Microsoft.AspNet.Identity.IdentityExtensions.GetUserName(identity);
			return true;
		}
		catch (ArgumentNullException ane)
		{
			username = null;
			return false;
		}
	}
