    var authorizationService = ctx.RequestServices.GetService<IAuthorizationService>();
    var authorizationResult = await authorizationService.AuthorizeAsync(
        authenticateResult.Principal, "PolicyName");
    if (!authorizationResult.Succeeded)
    {
        ctx.Response.StatusCode = 403; // e.g.
        return;
    }
    // ...
