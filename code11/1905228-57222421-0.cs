    public async Task ValidateAsync(CustomTokenRequestValidationContext context)
	{
		if (context.Result.ValidatedRequest.GrantType == "client_credentials")
		{
		...your logic
		}
	}
