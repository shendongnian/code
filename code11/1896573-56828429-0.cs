    var foo = new AuthorizationPolicyBuilder()
    			.RequireAuthenticatedUser();
    
    	if (!this.Roles.IsNull())
    	{
    		foo.RequireRole(this.Roles.Split(","));
    	}
    
    	if (!this.AuthenticationSchemes.IsNull())
    	{
    		foo.AddAuthenticationSchemes(this.AuthenticationSchemes);
    	}
    
    	var policy = foo.Build();
    	var authResult = await _eva.AuthenticateAsync(policy, _http.HttpContext);
    	var authorizeResult = await _eva.AuthorizeAsync(policy, authResult, _http.HttpContext, null);
    	
    	if (!authorizeResult.Succeeded)
    	{
    		output.SuppressOutput();
    	}
