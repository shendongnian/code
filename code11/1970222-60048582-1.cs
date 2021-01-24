    // Inject the repository
    public async Task Invoke(HttpContext context, IClaimsRepository repository)
    {
        if (context.User.Identity.IsAuthenticated)
        {
            // Get claims from (cached) database, singleton.
            var claims = await repository.GetClaimsAsync();
            if (claims.Count > 0)
            {
                var id = new ClaimsIdentity(claims, "MyMiddleware", "name", "role");
                // Add as extra Identity to User.
                context.User.AddIdentity(id);
            }
        }
        await _next(context);
    }
