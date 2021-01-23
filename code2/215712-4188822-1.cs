    // Register for application event notifications
    Messenger.Default.Register<NotificationMessage<AppEvent>>(this, n =>
    {
       switch (n.Content)
       {
          case AppEvent.Deactivated:
             // Save state here
             break;
             
          case AppEvent.Activate:
             // Restore state here
             break;
       }
    }
