    Messenger.Default.Register<NotificationMessageAction<string>>(
       this,
       msg =>
          {
               if (msg.Notification == "CanClose")
                   {
                       // Do the necessary UI logic and send the result back
                       msg.Execute(true);
                   }
          }
