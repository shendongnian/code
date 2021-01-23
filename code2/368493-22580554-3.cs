    container.RegisterType<HttpRequestBase>(new InjectionFactory(c =>
    {
        return new HttpRequestWrapper(HttpContext.Current.Request);
    }));
    container.RegisterType<HttpResponseBase>(new InjectionFactory(c =>
    {
        return new HttpResponseWrapper(HttpContext.Current.Response);
    }));
