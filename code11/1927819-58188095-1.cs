    public class AuthorizePolicyAttribute : AuthorizeAttribute
    {
        public AuthorizePolicyAttribute()
        {
            Policy = "CustomPolicy";
        }
    }
