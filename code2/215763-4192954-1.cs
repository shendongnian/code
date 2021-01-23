    private readonly SynchronizationContext _syncContext;
    public MainForm()
    {
        InitializeComponent();
        _syncContext = SynchronizationContext.Current;
    }
        
    void InvokeViaSyncContext(Action uiAction)
    {
        _syncContext.Post(o =>
        {
            if (IsHandleCreated && !IsDisposed) uiAction();
        }, null);
    }
        
    public void SomeMethodCalledFromAnyThread() //Sample usage
    {
        InvokeViaSyncContext(() => MyTextBox.Text = "Hello from another thread!"));    
    }
