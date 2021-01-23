    // Add to class:
    TaskFactory uiFactory;
    public MyViewModel()
    {
        // Construct a TaskFactory that uses the UI thread's context
        uiFactory = new TaskFactory(TaskScheduler.FromCurrentSynchronizationContext());
    }
