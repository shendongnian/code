    // the following will make sure that any errors that happen within the constructor
    // of any controller due to dependency injection error will also get logged
    GlobalConfiguration.Configuration.Services.Replace(typeof(IHttpControllerActivator),
              new ExceptionHandlingControllerActivator(                        
                 GlobalConfiguration.Configuration.Services.GetHttpControllerActivator())
                    );
ExceptionHandlingControllerActivator.cs
    /// <summary>
    /// This class handles instantiation of every api controller. It handles and logs 
    /// any exception that occurs during instatiation of each controller, e.g. errors
    /// that can happen due to dependency injection.
    /// </summary>
    public class ExceptionHandlingControllerActivator : IHttpControllerActivator
    {
        private IHttpControllerActivator _concreteActivator;
        private static readonly ILog _logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public ExceptionHandlingControllerActivator(IHttpControllerActivator concreteActivator)
        {
            _concreteActivator = concreteActivator;
        }
        public IHttpController Create(HttpRequestMessage request, HttpControllerDescriptor controllerDescriptor, Type controllerType)
        {
            try
            {
                return _concreteActivator.Create(request, controllerDescriptor, controllerType);
            }
            catch (Exception ex)
            {
                _logger.Error("Internal server error occured while creating API controller " + controllerDescriptor.ControllerName, ex);
                throw new HttpResponseException(request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Unexpected error while creating controller " + controllerDescriptor.ControllerName));
            }
        }
    }
