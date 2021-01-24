    public static class HttpContextAccessorExtensions
    {
        public static int GetUserId(this IHttpContextAccessor httpContextAccessor)
        {
            var value = httpContextAccessor.HttpContext.User?.Claims?.FirstOrDefault(claim => claim.Type == ClaimTypes.NameIdentifier)?.Value;
            if (Int32.TryParse(value, out int userId))
            {
                return userId;
            }
    
            return 0; // or whatever you want if userId is not found (I would suggest making return type int? and returning null here)
    
        }
    }
