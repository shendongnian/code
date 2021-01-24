    public MainWindow()
    {
        DataContext = VM = new CertifyingVM();
    
        VM.CommandRefreshBindings = new OperationCommand(o =>
        {
            MainAccessionHeader.DataContext =
            MainHeader.DataContext = null;
    
            MainAccessionHeader.DataContext =
            MainHeader.DataContext = VM;
    
            var currentBatch = VM.CurrentBatch;
            MainAccessionHeader.CurrentBatch = null;
            MainAccessionHeader.CurrentBatch = currentBatch;
    
        });
    
        VM.LockBatchGui = new OperationCommand(o =>
        { ... }
