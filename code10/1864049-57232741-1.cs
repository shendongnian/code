    public class ValidateThumbprint : FilterAttribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationContext filterContext)
        var identity = (ClaimsIdentity)filterContext.HttpContext.User.Identity;
        var thumbPrint = identity.Claims?.Where(s => s.Type == ClaimTypes.Thumbprint).First().Value;
        if (thumbPrint != null)
        {
            if (MemoryCache.Default.Contains(thumbPrint))
            {
                return;
            }
        }
            // handle invalid thumbprint
    }
