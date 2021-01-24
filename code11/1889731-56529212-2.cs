    public class HmacAuthentication
    {
        private const string ApiKey = "api-key";
        private RequestDelegate _next;
        
        public ApiKeyMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task Invoke(HttpContext context)
        {
            bool success = false;
            string[] claims = null;
            success = GetHeader(context.Request.Headers, out StringValues headerValue);
            if (success)
            {                
                success = ValidateKeyAndGetClaims(headerValue, out claims);                
            }
            if (success)
            {
                context.User = GetPrincipal(headerValue, claims);
                await _next(context);
            }
            else
            {
                context.Response.StatusCode = 401;
                await context.Response.WriteAsync("Unauthorized");
            }            
        }
        internal bool GetHeader(IHeaderDictionary headers, out StringValues headerValue)
        {
            return headers.TryGetValue(ApiKey, out headerValue);
        }
        internal bool ValidateKeyAndGetClaims(string, headerValue, out string[] claims)
        {
            // Validate the api-key.
            // Claims could depend on the key value or could be hardcoded
            claims = new [] { "IsAuthenticated" };
            return true;
        }        
        internal ClaimsPrincipal GetPrincipal(string apiKey, string[] claims)
        {
            var identity = new ClaimsIdentity();
            identity.AddClaim(new Claim(ClaimTypes.Name, apiKey));
            if (claims != null)
            {
                foreach(var claim in claims)
                {
                    identity.AddClaim(new Claim(claim, string.Empty));
                }
            }
            return new ClaimsPrincipal(identity);
        }
    }
