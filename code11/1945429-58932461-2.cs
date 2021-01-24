    private readonly IBackendWorker worker;
    private SynchronizationContext uiContext;
    public MainForm(IBackendWorker worker)
    {
        InitializeComponent();
        this.worker = worker;
        uiContext = SynchronizationContext.Current;
        worker.BackendEvent += OnWorkerBackEvent;
       ...
    }
