    public class ErrorHandlerAttribute : HandleErrorAttribute
        {
            public override void OnException(ExceptionContext exceptionContext)
            {
               LogManager.GetLogger("somelogger").Error(exceptionContext.Exception.Message,exceptionContext.Exception);
                base.OnException(exceptionContext);
            }
        }
