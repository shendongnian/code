    private void OnSaveCompleted(IAsyncResult result)
    {
        Action action = () =>
        {
            context.EndSaveChanges(result);
        };
        Dispatcher.BeginInvoke(action);
    }
