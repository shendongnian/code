    private async void RunNext()
    {
        IsBusy = true;
        ProgressMessage = "Wait 10 seconds...";
        await workToDo();
        ProgressMessage = "Work done!";
        IsBusy = false;
        if (callback != null)
        {
            callback.Invoke(Task.FromResult(true));
        }
    }
