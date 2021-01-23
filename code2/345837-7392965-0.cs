    TaskFactory uiFactory;
    public YourViewModel()
    {
         // Since the View handles the construction here, you'll get the proper sync. context
         uiFactory = new TaskFactory(TaskScheduler.FromCurrentSynchronizationContext());
    }
    // In your data received event:
    private items_DataReceived(object sender, EventArgs e)
    {
        uiFactory.StartNew( () =>
        {
            // update ObservableCollection here... this will happen on the UI thread
        });
    }
