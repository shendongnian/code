    class _anonymousClass
    {
        private HttpContext httpContext;
        public _anonymousClass(HttpContext httpContext)
        {
            this.httpContext = httpContext;
        }
    
        public void Callback()
        {
            this.httpContext.Response.Headers.Add("My-Header", "value");
        }
    }
    
    var httpContext = GetHttpContext();
    
    // No state object - OnStarting(Func<Task> callback)
    httpContext.Response.OnStarting(new _anonymousClass(httpContext).Callback);
    
