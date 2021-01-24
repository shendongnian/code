        public class AuthorizationHeaderRequirement: IAuthorizationRequirement
        {
        }
        public class AuthorizationHeaderHandler : AuthorizationHandler<AuthorizationHeaderRequirement>
        {
            protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, AuthorizationHeaderRequirement requirement)
            {
                // Requires the following import:
                //     using Microsoft.AspNetCore.Mvc.Filters;
                if (context.Resource is AuthorizationFilterContext mvcContext)
                {
                    // Examine MVC-specific things like routing data.
                    var httpContext = mvcContext.HttpContext;
                    if (httpContext.Request.Headers.ContainsKey("Authorization"))
                    {
                        context.Succeed(requirement);
                        return;
                    }
                    var failureResponse = new FailureResponseModel
                    {
                        Result = false,
                        ResultDetails = "Authorization header not present in request",
                        Uri = httpContext.Request.Path.ToUriComponent(),
                        Timestamp = DateTime.Now.ToString("s", CultureInfo.InvariantCulture),
                        Error = new Error
                        {
                            Code = 108,
                            Description = "Authorization header not present in request",
                            Resolve = "Send Request with authorization header to avoid this error."
                        }
                    };
                    var responseString = JsonConvert.SerializeObject(failureResponse);
                    mvcContext.Result = new ContentResult
                    {
                        Content = responseString,
                        ContentType = "application/json",
                        StatusCode = 403
                    };
                    await mvcContext.Result.ExecuteResultAsync(mvcContext);
                }
                return;
            }
        }
