    // Ensure that application state is restored appropriately
    private void Application_Activated(object sender, ActivatedEventArgs e)
    {
       Messenger.Default.Send(new NotificationMessage<AppEvent>(AppEvent.Activated, string.Empty));
    }
    
    // Ensure that required application state is persisted here.
    private void Application_Deactivated(object sender, DeactivatedEventArgs e)
    {
       Messenger.Default.Send(new NotificationMessage<AppEvent>(AppEvent.Deactivated, string.Empty));
    }
