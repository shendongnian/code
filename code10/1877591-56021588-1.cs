C#
bool IsAuthorized(HttpActionContext actionContext)
        {
            var valid = base.IsAuthorized(actionContext);
            // Custom handle for Bearer token, when invalid from base-class
            if (!valid && actionContext.Request.Headers.Authorization.Scheme == "Bearer")
            {
                var jwt = actionContext.Request.Headers.Authorization.Parameter;
                var th = new JwtSecurityTokenHandler();
                var validationParameters = new TokenValidationParameters
                {
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    ValidateIssuer = true,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new JsonWebKey(GetJWK()),
                    ValidIssuers = new[] { "https://substrate.office.com/sts/" }
                };
                Microsoft.IdentityModel.Tokens.SecurityToken validatedToken;
                try
                {
                    var claims = th.ValidateToken(jwt, validationParameters, out validatedToken);
                    valid = true;
                }
                catch (Exception ex)
                {
                    valid = false;
                }
            }
            return valid;
        }
        // Get the token from configuration
        private string GetJWK()
        {
            return ConfigurationManager.AppSettings["ida:jwks_json"];
        }
In the appsettings I put the RSA key from the website for validating the token, it looks like:
JSON
{"kty":"RSA","use":"sig","kid":"gY...","x5t":"gY...","n":"2w...","e":"AQAB","x5c":["MII..."]}
