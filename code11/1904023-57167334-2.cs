curl -d "grant_type=client_credentials&client_id=the-svc-client&client_secret=the-secret&acr_values=tenant:DevStable" https://login.my.site/connect/token
And the vlidator (partially copy&pasted from AuthRequestValidator):
cs
public Task ValidateAsync(CustomTokenRequestValidationContext context)
{
    var request = context.Result.ValidatedRequest;
    if (request.GrantType == OidcConstants.GrantTypes.ClientCredentials)
    {
        //////////////////////////////////////////////////////////
        // check acr_values
        //////////////////////////////////////////////////////////
        var acrValues = request.Raw.Get(OidcConstants.AuthorizeRequest.AcrValues);
        if (acrValues.IsPresent())
        {
            if (acrValues.Length > context.Result.ValidatedRequest.Options
                    .InputLengthRestrictions.AcrValues)
            {
                _logger.LogError("Acr values too long", request);
                context.Result.Error = "Acr values too long";
                context.Result.ErrorDescription = "Invalid acr_values";
                context.Result.IsError = true;
                return Task.CompletedTask;
            }
            var acr = acrValues.FromSpaceSeparatedString().Distinct().ToList();
            //////////////////////////////////////////////////////////
            // check custom acr_values: tenant
            //////////////////////////////////////////////////////////
            string tenant = acr.FirstOrDefault(x => x.StartsWith(nameof(tenant)));
            tenant = tenant?.Substring(nameof(tenant).Length+1);
            if (!tenant.IsNullOrEmpty())
            {
                var tenantInfo = _tenantService.GetTenantInfoAsync(tenant).Result;
                // if tenant is present in request but not in the list, raise error!
                if (tenantInfo == null)
                {
                    _logger.LogError("Requested tenant not found", request);
                    context.Result.Error = "Requested tenant not found";
                    context.Result.ErrorDescription = "Invalid tenant";
                    context.Result.IsError = true;
                }
                context.Result.ValidatedRequest.ClientClaims.Add(
                    new Claim(Constants.TenantIdClaimType, tenant));            
            }
        }
    }
    return Task.CompletedTask;
}
