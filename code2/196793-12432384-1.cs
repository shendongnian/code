    private void OnSaveCompleted(IAsyncResult result)
    {       
        Dispatcher.BeginInvoke(new Action(delegate
        {
            context.EndSaveChanges(result);
        }));
    }
 
