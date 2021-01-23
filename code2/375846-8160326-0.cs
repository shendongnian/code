    // Show we are no longer busy.
    this.Dispatcher.Invoke(DispatcherPriority.Background, (Action)delegate()
    {
        this.BusyMessage = null;
        this.IsBusy = false;
    });
