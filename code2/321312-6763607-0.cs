    public void CallbackLater(Action action)
    {
      Task.Factory.StartNew(action, CancellationToken.None,
        TaskCreationOptions.None, TaskScheduler.FromCurrentSynchronizationContext());
    }
    void MyObject_EventCallback(State info)
    {
      CallbackLater(() => Unhooked(info));
    }
