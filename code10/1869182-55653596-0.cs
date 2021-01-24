    public async Task GetProfileDataAsync(ProfileDataRequestContext context)
    {
        context.IssuedClaims.AddRange(context.Subject.Claims);
        var user = await _userManager.GetUserAsync(context.Subject);
        var roles = await _userManager.GetRolesAsync(user);
        foreach (var role in roles)
        {
            var roleClaims = await RoleManager.GetClaimsAsync(role);
            context.IssuedClaims.Add(new Claim(JwtClaimTypes.Role, role)); //Adds "role" claim
            context.IssuedClaims.AddRange(roleClaims); //Adds other role claims
        }
    }
