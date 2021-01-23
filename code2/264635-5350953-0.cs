    using (var scope = new OperationContextScope((IContextChannel)proxy))
    {
        Stream document = proxy.GetDocument(...);
        string contentType = WebOperationContext.Current.IncomingResponse.ContentType;
    }
