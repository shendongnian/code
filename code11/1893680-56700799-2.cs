    public class MyCustomAuthentication : ActionFilterAttribute, System.Web.Http.Filters.IAuthenticationFilter
    {
        public async Task AuthenticateAsync(HttpAuthenticationContext context, CancellationToken cancellationToken)
        {
            HttpRequestMessage request = context.Request;
            AuthenticationHeaderValue authorization = request.Headers.Authorization;
             // Handle the authorization header
        }
    }
