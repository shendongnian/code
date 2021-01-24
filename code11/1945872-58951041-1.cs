    protected string GetUserId()
    {
        if (this.httpContextAccessor.HttpContext.User.Identity is ClaimsIdentity identity)
        {
            IEnumerable<Claim> claims = identity.Claims;
            return claims.ToList()[0].Value;
        }
    
        return "";
    }
