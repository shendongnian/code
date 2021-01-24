    public static class ClaimsManager
    {
        public static UserIdentityState GetClaims( ClaimsPrincipal principal )
        {
            if (principal == null || !principal.Identity.IsAuthenticated)
            {
                return UserIdentityState.NotAuthenticated;
            }
            return new UserIdentityState {
                Name =  principal.Identity.Name,
                TenantId = incomingPrincipal.FindFirst("http://schemas.microsoft.com/identity/claims/tenantid")?.Value,
                IsAuthenticated = true
            };
        }
    }
