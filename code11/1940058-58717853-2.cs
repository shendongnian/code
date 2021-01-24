    public class GlobalExceptionHandler : ExceptionHandler
    {
        public async override Task HandleAsync(ExceptionHandlerContext context, CancellationToken cancellationToken)
        {
            // Access Exception
            // var exception = context.Exception;
     
            const string genericErrorMessage = &quot;An unexpected error occured&quot;;
            var response = context.Request.CreateResponse(HttpStatusCode.InternalServerError, 
                new
                { 
                    Message = genericErrorMessage
                });
     
            response.Headers.Add(&quot;X-Error&quot;, genericErrorMessage);
            context.Result = new ResponseMessageResult(response);
        }
    }
