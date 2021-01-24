    public class DecoderFallbackExceptionFilter : IExceptionFilter
    {
            public void OnException(ExceptionContext context)
            {
                if (context.Exception.GetType() == typeof(DecoderFallbackException))
                    context.Result = new BadRequestObjectResult(ShortURLResponse.InvalidURL());
            }
    }
