    public class AuthorizationFilter : IAsyncAuthorizationFilter
    {
        //use constructor to inject required dependencies
        public async Task OnAuthorizationAsync(AuthorizationFilterContext context)
        {
             //Move your custom logic here
        }
    }
