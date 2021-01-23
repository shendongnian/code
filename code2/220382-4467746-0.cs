	using System.DirectoryServices.AccountManagement;
	private static bool IsLdapAuthenticated(string username, string password)
	{
		PrincipalContext context;
		UserPrincipal principal;
		try
		{
			context = new PrincipalContext(ContextType.Domain);
			principal = Principal.FindByIdentity(context, IdentityType.SamAccountName, username) as UserPrincipal;
		}
		catch (Exception ex)
		{
			// handle server failure / user not found / etc
		}
		return context.ValidateCredentials(principal.UserPrincipalName, password);
	}
