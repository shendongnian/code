    public SomeWindowViewModel()
    {
        NavigatedCommand = new DelegateCommand<object>( x => { /* x is the browser's Document here */ } );
    }
    public DelegateCommand<object> NavigatedCommand { get; }
