    //...
    #region Constructor
    public RequestResponseLoggingMiddleware(RequestDelegate next) {
        _next = next;
    }
    #endregion
    //...
    #region FormatResponse
    private async Task<string> FormatResponseStream(Stream stream) {
        stream.Seek(0, SeekOrigin.Begin);
        var text = await new StreamReader(stream).ReadToEndAsync();
        stream.Seek(0, SeekOrigin.Begin);
        return $"Response {text}";
    }
    #endregion
    public async Task Invoke(HttpContext context, IActionLogPublish logger) {
        ActionLog actionLog = await FormatRequest(context.Request);
        //keep local copy of response stream
        var originalBodyStream = context.Response.Body;
        using (var responseBody = new MemoryStream()) {
            //replace stream for down stream calls
            context.Response.Body = responseBody;
            await _next(context);
            //put original stream back in the response object
            context.Response.Body = originalBodyStream; // <-- THIS IS IMPORTANT
            actionLog.Response = await FormatResponse(responseBody);
            await logger.Publish(actionLog);
            //Copy local stream to original stream
            await responseBody.CopyToAsync(originalBodyStream);
        }
    }
