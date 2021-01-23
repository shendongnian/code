    // when calling this with an actual T parameter, you have to either specify the type
    // explicitly or cast the parameter to T?.
    public void DoFoo<T>(T? foo) where T : struct, ISomeInterface<T>
    {
        if (foo == null)
        {
            // throw...
        }
        DoFooInternal(foo);
    }
    public void DoFoo<T>(T foo) where T : class, ISomeInterface<T>
    {
        if (foo == null)
        {
            // throw...
        }
        DoFooInternal(foo.Value); 
    }
    private void DoFooInternal<T>(T foo) where T : ISomeInterface<T>
    {
        // actual implementation
    }
