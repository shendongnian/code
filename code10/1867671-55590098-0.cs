    private void Window_ContentRendered(object sender, System.EventArgs e)
        {
            Task.Run(() =>
             {
                // Your code
    
             }).ContinueWith((tsk) =>
             {
                 this.Close();
             }, TaskScheduler.FromCurrentSynchronizationContext());
        }
