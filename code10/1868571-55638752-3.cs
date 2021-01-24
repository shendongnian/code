    public class LoggingInterceptor : IInterceptor
    {
        private readonly IUserContext _userContext;
        private readonly ILogger _logger;
        public CallLogger(IUserContext userContext, ILogger logger)
        {
            _userContext = userContext;
            _logger = logger;
        }
        public void Intercept(IInvocation invocation)
        {
            var user = _userContext.GetCurrentUser();
            _logger.Log( 
             // some stuff about the invocation, like method name and maybe parameters)
             // and who the user was.
             // Or if you were checking permissions you could throw an exception here.
            invocation.Proceed();
        }
    }
