    public override void ExecuteResult(ControllerContext context)
    {
        // Set TrySkipIisCustomErrors to ensure ASP.NET sends your error content to the
        // user instead of the default ASP.NET content under IIS 7.
        context.HttpContext.Response.TrySkipIisCustomErrors = true;
        context.HttpContext.Response.StatusCode = _statusCode;
        context.HttpContext.Response.StatusDescription = _statusMessage;
        
        if(_errorMessage != null)
        {
            [...]
        }
    }
