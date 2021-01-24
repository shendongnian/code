	public async Task<AuthenticationResult> RequestTokenAsync(
		ClaimsPrincipal claimsPrincipal,
		string authorizationCode,
		string redirectUri,
		string resource)
	{
		try
		{
			var userId = claimsPrincipal.GetObjectIdentifierValue();
			var issuerValue = claimsPrincipal.GetIssuerValue();
			var authenticationContext = await CreateAuthenticationContext(claimsPrincipal)
				.ConfigureAwait(false);
			var authenticationResult = await authenticationContext.AcquireTokenByAuthorizationCodeAsync(
				authorizationCode,
				new Uri(redirectUri),
				new ClientCredential(_adOptions.ClientId, _adOptions.ClientSecret),
				resource)
				.ConfigureAwait(false);
	 
			return authenticationResult;
		}
		catch (Exception)
		{
			throw;
		}
	}
