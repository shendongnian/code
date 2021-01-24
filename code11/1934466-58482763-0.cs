    public class CustomTokenService : DefaultTokenService
    {
        public CustomTokenService(IClaimsService claimsProvider
            , IReferenceTokenStore referenceTokenStore
            , ITokenCreationService creationService
            , IHttpContextAccessor contextAccessor
            , ISystemClock clock
            , IKeyMaterialService keyMaterialService
            , ILogger<DefaultTokenService> logger) 
            : base(claimsProvider, referenceTokenStore, creationService, contextAccessor, clock, keyMaterialService, logger)
        {
        }
        public override async Task<Token> CreateAccessTokenAsync(TokenCreationRequest request)
        {
            Logger.LogTrace("Creating access token");
            request.Validate();
            var claims = new List<Claim>();
            claims.AddRange(await ClaimsProvider.GetAccessTokenClaimsAsync(
                request.Subject,
                request.Resources,
                request.ValidatedRequest));
            if (request.ValidatedRequest.Client.IncludeJwtId)
            {
                claims.Add(new Claim(JwtClaimTypes.JwtId, CryptoRandom.CreateUniqueId(16)));
            }
            claims.Add(new Claim(JwtClaimTypes.Name, request.Subject.GetDisplayName()));
            var issuer = Context.HttpContext.GetIdentityServerIssuerUri();
            var token = new Token(OidcConstants.TokenTypes.AccessToken)
            {
                CreationTime = Clock.UtcNow.UtcDateTime,
                Issuer = issuer,
                Lifetime = request.ValidatedRequest.AccessTokenLifetime,
                Claims = claims.Distinct(new ClaimComparer()).ToList(),
                ClientId = request.ValidatedRequest.Client.ClientId,
                AccessTokenType = request.ValidatedRequest.AccessTokenType
            };
            foreach (var api in request.Resources.ApiResources)
            {
                if (!string.IsNullOrWhiteSpace(api.Name))
                {
                    token.Audiences.Add(api.Name);
                }
            }
            return token;
        }
    }
