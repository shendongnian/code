cs
public class AnotherAntiForgeryTokenAttribute : TypeFilterAttribute
{
    public AnotherAntiForgeryTokenAttribute() : base(typeof(AnotherAntiforgeryFilter))
    {
    }
}
public class AnotherAntiforgeryFilter:ValidateAntiforgeryTokenAuthorizationFilter,
    IAsyncAuthorizationFilter
{
    public AnotherAntiforgeryFilter(IAntiforgery a, ILoggerFactory l) : base(a, l)
    {
    }
    async Task IAsyncAuthorizationFilter.OnAuthorizationAsync(
        AuthorizationFilterContext ctx)
    {
        await base.OnAuthorizationAsync(ctx);
        if (ctx.Result is IAntiforgeryValidationFailedResult)
        {
            // the next four rows are optional, just illustrating a way
            // to save some sensitive data such as initial query
            // the form has to support that
            var request = ctx.HttpContext.Request;
            var url = request.Path.ToUriComponent();
            if (request.Form?["ReturnUrl"].Count > 0)
                url = $"{url}?ReturnUrl={Uri.EscapeDataString(request.Form?["ReturnUrl"])}";
            // and the following is the only real customization
            ctx.Result = new LocalRedirectResult(url);
        }
    }
}
