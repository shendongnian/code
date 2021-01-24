    public ExceptionMiddleware(RequestDelegate next,IMailService emailSender)
    {
        ...
    }
    
    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch(Exception ex)
        {
            await EmailException(context, ex); // Await.
        }
    }
    
    private async Task EmailException(HttpContext context, Exception ex) // Return a Task.
    {
        ...
    
        throw ex;
    }
