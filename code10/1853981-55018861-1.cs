    public override void Handle(ExceptionHandlerContext context)
    {
        var result = new HttpResponseMessage(HttpStatusCode.InternalServerError)
        {
            Content = new StringContent("Internal Server Error Occurred"),
            ReasonPhrase = "Exception"
        };
        context.Result = new ErrorMessageResult(context.Request, result);
    }
