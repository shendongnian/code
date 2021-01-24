    public async Task<ObjectResult> Invoke(HttpContext context)
    {
        bool result = context.Request.Headers["Accept"].ToString() == "app/version.abc-ghi-api.v";
        if (result)
        {
            await  _next(context);   
        }
        else
        {
            context.Result.StatusCode = 500;
        }
    }
