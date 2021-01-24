    public class UrlRequestCultureProvider : RequestCultureProvider
    {
        public override Task<ProviderCultureResult> DetermineProviderCultureResult(HttpContext httpContext)
        {
            var validCultures = new []{"en", "de", "fr", "nl"};
            if (httpContext == null)
            {
                throw new ArgumentNullException(nameof(httpContext));
            }
            if (!httpContext.User.Identity.IsAuthenticated)
            {
                return Task.FromResult((ProviderCultureResult)null);
            }
            var culture = httpContext.Request.Path.Value
                            .Split("/")
                            .FirstOrDefault( (p) => validCultures.IndexOf(p.ToLower()) >= 0);
            if (culture == null)
            {
                return Task.FromResult((ProviderCultureResult)null);
            }
            return Task.FromResult(new ProviderCultureResult(culture));
        }
    }
