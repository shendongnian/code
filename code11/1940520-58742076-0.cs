    public class RequestLoggingHandler : AuthorizationHandler<RequestLoggingRequirement>
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public RequestLoggingHandler(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, RequestLoggingRequirement requirement)
        {
            try
            {
                var httpContext = _httpContextAccessor.HttpContext;
                var request = httpContext.Request;
                request.EnableBuffering();
                httpContext.Items["requestId"] = SaveRequest(request);
                context.Succeed(requirement);
                return Task.CompletedTask;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private int SaveRequest(HttpRequest request)
        {
            try
            {
                // Allows using several time the stream in ASP.Net Core
                var buffer = new byte[Convert.ToInt32(request.ContentLength)];
                request.Body.ReadAsync(buffer, 0, buffer.Length);
                var requestContent = Encoding.UTF8.GetString(buffer);
                var requestId = _repository.SaveRawHandlerRequest($"{request.Scheme} {request.Host}{request.Path} {request.QueryString} {requestContent}");
                request.Body.Position = 0;//rewinding the stream to 0
                return requestId;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
