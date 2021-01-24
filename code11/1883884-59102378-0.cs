    public class CustomAntiForgeryTokenAttribute : TypeFilterAttribute
    {
        public CustomAntiForgeryTokenAttribute() : base(typeof(AnotherAntiforgeryFilter))
        {
        }
    }
    public class AnotherAntiforgeryFilter : ValidateAntiforgeryTokenAuthorizationFilter,
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
                ctx.ModelState.AddModelError("Token", "Validation Token Expired. Please try again");
                ctx.Result = null;
            }
        }
    }
