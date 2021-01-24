    var context = Request.GetOwinContext();
    var authManager = context.Authentication;
    authManager.SignIn(new AuthenticationProperties
    {
        IsPersistent = model.RememberMe,
        ExpiresUtc = DateTimeOffset.UtcNow.AddHours(4)
    }, identity);
