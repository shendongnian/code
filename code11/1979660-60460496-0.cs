    T Handle<T>(Func<T> call)
    {
        try
        {
            return call();
        }
        catch(YourException ex)
        {
            return default;
        }
    }
    void Handle(Action call)
    {
        try
        {
            call();
        }
        catch(YourException ex)
        {
            
        }
    }
