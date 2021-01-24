	// Build URL based on your AAD-TenantId
	var stsDiscoveryEndpoint = String.Format(CultureInfo.InvariantCulture, "https://login.microsoftonline.com/{0}/.well-known/openid-configuration", "<Your_tenant_ID>");
	// Get tenant information that's used to validate incoming jwt tokens
	var configManager = new ConfigurationManager<OpenIdConnectConfiguration>(stsDiscoveryEndpoint);
	// Get Config from AAD:
	var config = await configManager.GetConfigurationAsync();
	// Validate token:
	var tokenHandler = new JwtSecurityTokenHandler();
	var validationParameters = new System.IdentityModel.Tokens.TokenValidationParameters
	{
		ValidAudience = "<Client_ID>",
		ValidIssuer = "<Issuer>",
		IssuerSigningTokens = config.SigningTokens,
		CertificateValidator = X509CertificateValidator.ChainTrust
	};
	var parsedToken = (System.IdentityModel.Tokens.SecurityToken)new JwtSecurityToken();
	try
	{
		tokenHandler.ValidateToken(token, validationParameters, out parsedToken);
		result.ValidatedToken = (JwtSecurityToken)parsedToken;
	}
	catch (System.IdentityModel.Tokens.SecurityTokenValidationException stve)
	{
		// Handle error using stve.Message
	}
