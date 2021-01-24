    public class CurrentDomainCookieBuilder : CookieBuilder
    {
        public override CookieOptions Build(HttpContext context, DateTimeOffset expiresFrom)
        {
            if (string.IsNullOrEmpty(Domain))
                Domain = string.Join('.', context.Request.Host.Host.Split('.').Skip(1));
            return base.Build(context, expiresFrom);
        }
    }
