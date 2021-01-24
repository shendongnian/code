    public Func<RedirectContext<CookieAuthenticationOptions>, Task> OnRedirectToAccessDenied { get; set; } = (Func<RedirectContext<CookieAuthenticationOptions>, Task>) (context =>
    {
        if (CookieAuthenticationEvents.IsAjaxRequest(context.Request))
        {
        context.Response.Headers["Location"] = (StringValues) context.RedirectUri;
        context.Response.StatusCode = 403;
        }
        else
        context.Response.Redirect(context.RedirectUri);
        return Task.CompletedTask;
    });
