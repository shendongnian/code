    public class ClaimsTransformationMiddleware
    {
        readonly ClaimsTransformationOptions _options;
        readonly Func<IDictionary<string, object>, Task> _next;
        public ClaimsTransformationMiddleware(Func<IDictionary<string, object>, Task> next, ClaimsTransformationOptions options)
        {
            _next = next;
            _options = options;
        }
        public async Task Invoke(IDictionary<string, object> env)
        {
            // use Katana OWIN abstractions (optional)
            var context = new OwinContext(env);
            if (context.Authentication != null &&
                context.Authentication.User != null)
            {
                var transformedPrincipal = await _options.ClaimsTransformation(context.Authentication.User);
                context.Authentication.User = new ClaimsPrincipal(transformedPrincipal);
            }
            await _next(env);
        }
    }
    
