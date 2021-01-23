    protected void Application_Error(object sender, EventArgs e)
            {
                //first, find the exception.  any exceptions caught here will be wrapped
                //by an httpunhandledexception, which doesn't realy help us, so we'll
                //try to get the inner exception
                Exception exception = Server.GetLastError();
                if (exception.GetType() == typeof(HttpUnhandledException) && exception.InnerException != null)
                {
                    exception = exception.InnerException;
                }
    
                //get a logger from the container
                ILogger logger = ObjectFactory.GetInstance<ILogger>();
                //log it
                logger.FatalException("Global Exception", exception);
            }
