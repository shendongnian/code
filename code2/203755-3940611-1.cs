    public void SetResponseHttpStatus(HttpStatusCode statusCode)
    {
        var context = WebOperationContext.Current;
        context.OutgoingResponse.StatusCode = statusCode;
    }
