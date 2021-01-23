    public void Button1_OnClick(sender object, EventArgs e)
    {
        // Get the current SynchronizationContext.
        // NOTE: Must make the call on the UI thread, NOT
        // the background thread to get the proper
        // context.
        SynchronizationContext context = SynchronizationContext.Current;
    
        // Start some work on a new Task (4.0)
        Task.Factory.StartNew(() => { 
            // Do some lengthy operation.
            ...
    
            // Notify the user.  Do not need to wait.
            context.Post(o => MessageBox.Show("Progress"));
    
            // Do some more stuff.
            ...
    
            // Wait on result.
            // Notify the user.
            context.Send(o => MessageBox.Show("Progress, waiting on OK"));
        });
    }
