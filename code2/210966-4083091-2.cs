    class Provider<T>
    {
        public T Instance { get; set; }
    }
    
    static Action Create(Provider<Foo> provider)
    {
        return foo =>
        {
            provider.Instance.Baz();
        };
    }
    
    // ...
    
    // Creation.
    var provider = new Provider<Foo>();
    var bar = Create(provider);
    
    // Invocation.
    provider.Instance = new Foo();
    bar();
