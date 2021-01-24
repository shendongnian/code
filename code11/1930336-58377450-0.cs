    public async Task Invoke(HttpContext context) {
        ActionLog actionLog = await FormatRequest(context.Request);
        //keep local copy of response stream
        var originalBodyStream = context.Response.Body;
        using (var responseBody = new MemoryStream()) {
            //replace stream for down stream calls
            context.Response.Body = responseBody;
            await _next(context);
            actionLog.Response = await FormatResponse(context.Response);
            await _logPublish.Publish(actionLog);
            //put original stream back in the response object
            context.Response.Body = originalBodyStream; // <-- THIS IS IMPORTANT
            await responseBody.CopyToAsync(originalBodyStream);
        }
    }
