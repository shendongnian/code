    public class CustomClaimsService : DefaultClaimsService
    {
        public CustomClaimsService(IProfileService profile
            , ILogger<DefaultClaimsService> logger) : base(profile, logger)
        {
        }
        protected override IEnumerable<Claim> GetStandardSubjectClaims(ClaimsPrincipal subject)
        {
            var claims = base.GetStandardSubjectClaims(subject);
            var newClaims = new List<Claim>(claims)
            {
                new Claim(JwtClaimTypes.Name, subject.Identity.Name)
            };
            return newClaims;
        }
    }
