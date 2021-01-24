    Constructor()
    {
        Task.Run( async () => await InitializeAsync() );
    }
    string Property
    {
        get => _backingField;
        set
        {
            if (_isInitialized && SetProperty( ref _backingField, value ))
                _isDirty = true;
        }
    }
    private async Task InitializeAsync()
    {
        await SomeAsynchronousStuff();
        _isInitialized = true;
    }
    private bool _isInitialized;
    private bool _isDirty;
