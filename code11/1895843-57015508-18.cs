    // **THIS CLASS IS ONLY TO DEMONSTRATE HOW THE ROLES NEED TO BE SETUP **
    public class CreateFakeIdentityMiddleware
    {
        private readonly RequestDelegate _next;
    
        public CreateFakeIdentityMiddleware(RequestDelegate next)
        {
            _next = next;
        }
    
        private readonly Dictionary<string, string[]> _tenantRoles = new Dictionary<string, string[]>
        {
            ["tenant1"] = new string[] { "Admin", "Reader" },
            ["tenant2"] = new string[] { "Reader" },
        };
    
        public async Task InvokeAsync(HttpContext context)
        {
            // Assume this is the roles
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, "John"),
                new Claim(ClaimTypes.Email, "john@someemail.com")
            };
    
            foreach (KeyValuePair<string, string[]> tenantRole in _tenantRoles)
            {
                claims.AddRange(tenantRole.Value.Select(x => new Claim(ClaimTypes.Role, $"{tenantRole.Key}:{x}".ToLower())));
            }
            
            // Note: You need these for the AuthorizeAttribute.Roles    
            claims.AddRange(_tenantRoles.SelectMany(x => x.Value)
                .Select(x => new Claim(ClaimTypes.Role, x.ToLower())));
    
            context.User = new System.Security.Claims.ClaimsPrincipal(new ClaimsIdentity(claims,
                "Bearer"));
    
            await _next(context);
        }
    }
