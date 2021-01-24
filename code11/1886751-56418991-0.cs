	using Microsoft.IdentityModel.Clients.ActiveDirectory;
	private static string redirectUri = "https://login.live.com/oauth20_desktop.srf";
	private static string resourceUri = "https://analysis.windows.net/powerbi/api";
	private static string authorityUri = "https://login.windows.net/common/oauth2/authorize";
	private static string clientId = "xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx";
	private static AuthenticationContext authContext = new AuthenticationContext(authorityUri, new TokenCache());
	// First check is there token in the cache
	try
	{
		authenticationResult = authContext.AcquireTokenSilentAsync(resourceUri, clientId).Result;
	}
	catch (AggregateException ex)
	{
		AdalException ex2 = ex.InnerException as AdalException;
		if ((ex2 == null) || (ex2 != null && ex2.ErrorCode != "failed_to_acquire_token_silently"))
		{
			throw new ApplicationException(ex.Message);
		}
	}
	if (authenticationResult == null)
	{
		var uc = new UserPasswordCredential(masterAccountName, masterAccountPassword);
		authenticationResult = authContext.AcquireTokenAsync(resourceUri, clientId, uc).Result;
	}
