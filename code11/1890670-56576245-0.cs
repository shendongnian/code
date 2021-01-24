    public class ApplicationClaimsIdentityFactory : Microsoft.AspNetCore.Identity.UserClaimsPrincipalFactory<IdentityUser>
    {
        UserManager<IdentityUser> _userManager;
        public ApplicationClaimsIdentityFactory(UserManager<IdentityUser> userManager,
            IOptions<IdentityOptions> optionsAccessor) : base(userManager, optionsAccessor)
        { }
        public async override Task<ClaimsPrincipal> CreateAsync(IdentityUser user)
        {
            var principal = await base.CreateAsync(user);
                ((ClaimsIdentity)principal.Identity).AddClaims(new[] {
                new Claim("Over18Claim", "true")
            });
            return principal;
        }
    }
