    public class TokenAuthenticate : Attribute, IAuthenticationFilter
        {
    
            public bool AllowMultiple
            {
                get
                {
                    return false;
                }
            }
    
            public async Task AuthenticateAsync(HttpAuthenticationContext context, CancellationToken cancellationToken)
            {
                try
                {
                    IAuthService _authService = context.ActionContext.ControllerContext.Configuration
                                      .DependencyResolver.GetService(typeof(IAuthService)) as IAuthService;
    
                    HttpRequestMessage request = context.Request;
                    AuthenticationHeaderValue authorization = request.Headers.Authorization;
    
                    if (authorization == null)
                    {
                        context.ErrorResult = new AuthenticationFailureResult("Missing autorization header", request);
                        return;
                    }
                    if (authorization.Scheme != "Bearer")
                    {
                        context.ErrorResult = new AuthenticationFailureResult("Invalid autorization scheme", request);
                        return;
                    }
                    if (String.IsNullOrEmpty(authorization.Parameter))
                    {
                        context.ErrorResult = new AuthenticationFailureResult("Missing Token", request);
                        return;
                    }
    
                    Boolean correctToken = await _authService.ValidateTokenAsync(authorization.Parameter);
                    if(!correctToken)
                        context.ErrorResult = new AuthenticationFailureResult("Invalid Token", request);
                }
                catch (Exception ex)
                {
                    context.ErrorResult = new AuthenticationFailureResult("Exception: \n" + ex.Message, context.Request);
                }
            }
    
        }
