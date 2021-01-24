    public class HMACAuthenticationAttribute, IAsyncAuthorizationFilter
    {
      
        public HMACAuthenticationAttribute()
        {
                 
        }
        public async Task OnAuthorizationAsync(AuthorizationFilterContext context)
        {
            var user = context.HttpContext.RequestServices.GetRequiredService<IUserService>();
            
        }
    }
