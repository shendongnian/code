    public void Configuration(IAppBuilder app)
    {
        app.UseClaimsTransformation(Transformation);
    }
    private async Task<ClaimsPrincipal> Transformation(ClaimsPrincipal incoming)
    {
        if (!incoming.Identity.IsAuthenticated)
        {
            return incoming;
        }
        var name = incoming.Identity.Name;
        // go to a datastore - find the app specific claims
        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, name),
            new Claim(ClaimTypes.Role, "foo"),
            new Claim(ClaimTypes.Email, "foo@foo.com")
        };
        var id = new ClaimsIdentity("Windows");
        id.AddClaims(claims);
        return new ClaimsPrincipal(id);
    }
    
