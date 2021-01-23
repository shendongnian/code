    private void OnSaveCompleted(IAsyncResult result)
    {       
        Dispatcher.BeginInvoke(new Action(() =>
        {
            context.EndSaveChanges(result);
        }));
    }
 
