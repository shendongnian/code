    private void _anonymousCallback(object state)
    {
        var headers = (IHeaderDictionary)state;
    
        headers.Add("My-Header", "value");
    }
    
    // Use state object - OnStarting(Func<object, Task> callback, object state);
    httpContext.Response.OnStarting(_anonymousCallback, httpContext.Response.Headers);
