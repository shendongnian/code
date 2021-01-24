    public class AuthHeaderHandler : DelegatingHandler
    {
        private readonly HttpContext _httpContext;
        public AuthorizationHeaderHandler(IHttpContextAccessor contextAccessor)
        {
            _httpContext = contextAccessor.HttpContext;
        }
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request,
            CancellationToken cancellationToken)
        {
            if (_httpContext != null)
            {
                var accessToken = await _httpContext.GetTokenAsync(TokenKeys.Access);
                if (!string.IsNullOrEmpty(accessToken))
                {
                    // modify the request header with the new Authorization token
                    request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
                }
            }
            return await base.SendAsync(request, cancellationToken);
        }
    }
