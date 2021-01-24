    public Task WriteAsync(OutputFormatterWriteContext context)
    {
        var response = context.HttpContext.Response;
        response.ContentLength = 0;
        if (response.StatusCode == StatusCodes.Status200OK)
        {
            response.StatusCode = StatusCodes.Status204NoContent;
        }
        return Task.CompletedTask;
    }
