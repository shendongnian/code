    var observable = new Subject<Bar>();
    _components.WithSsoToken(_configuration.SsoToken)
        .Get(@params)
        .Select(Map)
        .Subscribe(c =>
        {
            _cache.Add(@params, c);
            observable.OnNext(c);
            observable.OnCompleted();
        }, exception =>
        {
            observable.OnError(exception);
        });
    return observable.AsObservable();
