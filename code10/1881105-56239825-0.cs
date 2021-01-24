     public class ActAsGrantValidator : IExtensionGrantValidator
        {
            private readonly ITokenValidator _tokenValidator;
            private readonly ITenantStore _tenantStore;
            public ActAsGrantValidator(ITokenValidator tokenValidator, ITenantStore tenantStore)
            {
                _tokenValidator = tokenValidator;
                _tenantStore = tenantStore;
            }
            public string GrantType => "act-as";
    
            public async Task ValidateAsync(ExtensionGrantValidationContext context)
            {
                var userToken = context.Request.Raw.Get("accessToken");
                var tenant = context.Request.Raw.Get("chosenTenant");
    
                if (string.IsNullOrEmpty(userToken))
                {
                    context.Result = new GrantValidationResult(TokenRequestErrors.InvalidGrant);
                    return;
                }
    
                var result = await _tokenValidator.ValidateAccessTokenAsync(userToken);
                if (result.IsError)
                {
                    context.Result = new GrantValidationResult(TokenRequestErrors.InvalidGrant);
                    return;
                }
                // logic to validate the user and tenant
                // ..
                // issue a new claimsprincipal to reflect the new "persona"
                var claims = result.Claims.ToList();
                claims.RemoveAll(p => p.Type == "role");
                claims.RemoveAll(p => p.Type == "chosentenant");
                claims.Add(new Claim("chosentenant", tenant));
                var identity = new ClaimsIdentity(claims);
                var principal = new ClaimsPrincipal(identity);
                context.Result = new GrantValidationResult(principal);
                return;
           }
        }
