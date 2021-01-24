    public class IDPAuthenticationFilter : Attribute, IAuthenticationFilter 
    {
        public bool AllowMultiple => false;
        public async Task AuthenticateAsync (HttpAuthenticationContext context, CancellationToken cancellationToken) 
        {
            HttpRequestMessage request = context.Request;
            AuthenticationHeaderValue authorization = request.Headers.Authorization;
            if (authorization == null) {
                return;
            }
            if (authorization.Scheme != "Bearer") {
                return;
            }
            var claims = new List<Claim> ();
            claims.Add (new Claim (ClaimTypes.Name, "testUser"));
            claims.Add (new Claim (ClaimTypes.Role, "client"));
            claims.Add (new Claim ("sub", "testUser"));
            claims.Add (new Claim("APP:USERID", "50123"));
            var identity = new ClaimsIdentity (claims, "Auth_Key");
            var principal = new ClaimsPrincipal (new [] { identity });
            context.Principal = principal;
            HttpContext.Current.User = context.Principal;
            Thread.CurrentPrincipal = context.Principal;
        }
    }
