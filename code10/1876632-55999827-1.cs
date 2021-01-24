        public class ProblemDetailsErrorFactory: IClientErrorFactory
        {
            private static readonly string TraceIdentifierKey = "traceId";
            private static readonly string ErrorsKey = "errors";
            private readonly ApiBehaviorOptions _options;
            public ProblemDetailsErrorFactory(IOptions<ApiBehaviorOptions> options)
            {
                _options = options?.Value ?? throw new ArgumentNullException(nameof(options));
            }
            public IActionResult GetClientError(ActionContext actionContext, IClientErrorActionResult clientError)
            {
                var problemDetails = new ProblemDetails
                {
                    Status = clientError.StatusCode,
                    Type = "about:blank",
                };
                if (clientError.StatusCode is int statusCode &&
                    _options.ClientErrorMapping.TryGetValue(statusCode, out var errorData))
                {
                    problemDetails.Title = errorData.Title;
                    problemDetails.Type = errorData.Link;
                    SetErrors(actionContext, problemDetails);
                    SetTraceId(actionContext, problemDetails);
                }
                return new ObjectResult(problemDetails)
                {
                    StatusCode = problemDetails.Status,
                    ContentTypes =
                    {
                        "application/problem+json",
                        "application/problem+xml",
                    },
                };
            }
            internal static void SetErrors(ActionContext actionContext, ProblemDetails problemDetails)
            {
                if (actionContext is ResultExecutingContext resultExecutingContext)
                {
                    if (resultExecutingContext.Result is BadRequestObjectResult result)
                    {
                        problemDetails.Extensions[ErrorsKey] = result.Value;
                    }
                }
                //var errors = actionContext.HttpContext.
            }
            internal static void SetTraceId(ActionContext actionContext, ProblemDetails problemDetails)
            {
                var traceId = Activity.Current?.Id ?? actionContext.HttpContext.TraceIdentifier;
                problemDetails.Extensions[TraceIdentifierKey] = traceId;
            }
        }
 
